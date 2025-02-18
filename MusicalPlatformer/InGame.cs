﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kokoro.Math;
using Kokoro.Engine;
using Kokoro.Debug;
using Kokoro.Engine.SceneGraph;
using Kokoro.Engine.Prefabs;
using Kokoro.Engine.Shaders;
using Kokoro.Engine.HighLevel.CharacterControllers;
using Kokoro.Engine.HighLevel.Cameras;
using Kokoro.Engine.HighLevel;
using Kokoro.Engine.HighLevel.Rendering;
using Kokoro.Engine.HighLevel.Rendering.Compositor;
using Kokoro.Engine.Input;

namespace MusicalPlatformer
{
    class InGame : IScene
    {
        Entity eBox;
        GBuffer gbuf;
        CompositionPass blurCompositor;

        Model BoxB, Player, FSQ;
        Vector4[] Colors;
        ThirdPersonController2D PlayerController;
        Camera followCam;
        BroadPhaseWorld world;
        bool loaded = false;

        public InGame(GraphicsContext context)
        {
            context.Wireframe = true;

            context.ResourceManager += LoadResources;
        }

        public IScene Parent
        {
            get;
            set;
        }

        double i = 0;
        public void Render(double interval, GraphicsContext context)
        {
            context.Clear(0f, 0f, 0f, 1f);
            if (loaded)
            {
                gbuf.Bind(context);
                context.Clear(0, 0f, 0, 0f);

                //context.DrawMode = DrawMode.LineStrip;

                eBox.Renderable.Materials[0].Shader["inColor"] = Colors[0];
                world.Render(interval, context);
                context.ForceDraw();

                BoxB.Materials[0].Shader["inColor"] = Colors[1];
                BoxB.Draw(context);
                context.ForceDraw();

                Player.Materials[0].Shader["inColor"] = new Vector4(1, 1, 1, 1);
                Player.Draw(context);
                context.ForceDraw();

                //context.DrawMode = DrawMode.Triangles;
                gbuf.UnBind(context);

                var outBuf = blurCompositor.ApplyPass(context, gbuf);
                outBuf["RGBA0"].FilterMode = TextureFilter.Linear;
                gbuf["RGBA0"].FilterMode = TextureFilter.Linear;

                FSQ.Materials[0].Shader["SourceB"] = outBuf["RGBA0"];
                FSQ.Materials[0].Shader["SourceA"] = gbuf["RGBA0"];
                FSQ.Materials[0].Shader["weightSrcA"] = 1f;
                FSQ.Materials[0].Shader["weightSrcB"] = 0f;
                FSQ.Draw(context);

            }
            context.SwapBuffers();
        }

        public void Update(double interval, GraphicsContext context)
        {
            if (loaded)
            {
                PlayerController.Update(interval, context);
                Player.World = Matrix4.CreateTranslation(PlayerController.Position);
                //context.Camera.Position = PlayerController.Position;

                if (PlayerController.Position.X > -0.25f)
                {
                    Colors[1].X = 1f;
                    Colors[0].X = 0f;
                }
                else
                {
                    Colors[0].X = 1f;
                    Colors[1].X = 0f;
                }

                if (Mouse.ButtonsDown.Middle)
                {
                    eBox.Visible = !eBox.Visible;
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void LoadResources(GraphicsContext context)
        {
            if (world == null)
            {
                world = new BroadPhaseWorld(100, 10);
                world.DrawDistance = 1;
            }

            if (eBox == null)
            {
                eBox = new Entity()
                {
                    ID = 1,
                    Renderable = new Sphere(1, 10),
                    Position = new Vector3(-0.5f, -0.25f, 0),
                    Visible = true
                };
                eBox.Renderable.Materials[0].Shader = Kokoro.ShaderLib.ColorDefaultShader.Create();
                world.Add(eBox);
            }

            if (BoxB == null)
            {
                BoxB = new Sphere(10, 200);
                BoxB.World = Matrix4.CreateTranslation(0, -0.20f, 0);
                BoxB.Materials[0].Shader = Kokoro.ShaderLib.ColorDefaultShader.Create();
            }

            if (Colors == null)
            {
                Colors = new Vector4[2];
                Colors[0] = new Vector4(1, 0, 0, 0.5f);
                Colors[1] = new Vector4(0, 0, 1, 0.5f);
            }

            if (Player == null)
            {
                Player = new Sphere(0.025f, 10);
                Player.Materials[0].Shader = Kokoro.ShaderLib.ColorDefaultShader.Create();

                PlayerController = new ThirdPersonController2D(Vector3.Zero);
                PlayerController.MoveSpeed = 0.1f;
            }

            if (followCam == null)
            {
                followCam = new FirstPersonCamera(Vector3.Zero, Vector3.UnitY);
                (followCam as FirstPersonCamera).moveSpeed = 0.2f;
                //followCam = new FollowPointCamera();
                context.Camera = followCam;
            }

            if (gbuf == null)
            {
                gbuf = new GBuffer(1920, 1080, context);
                FSQ = new FullScreenQuad();
                FSQ.Materials[0].Shader = Kokoro.ShaderLib.BlendShader.Create(BlendingFactor.ConstantAlpha, BlendingFactor.ConstantAlpha);
            }

            if (blurCompositor == null)
            {
                blurCompositor = new CompositionPass(1920 / 2, 1080 / 2, context);
                blurCompositor.Steps.Add(new HorizontalGaussianBlurNode(17, 0.005f));
                blurCompositor.Steps.Add(new VerticalGaussianBlurNode(17, 0.005f));
            }

            loaded = true;
        }
    }
}
