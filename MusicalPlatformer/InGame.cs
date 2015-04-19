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

namespace MusicalPlatformer
{
    class InGame : IScene
    {
        Entity eBox;
        Model BoxB, Player;
        Vector4[] Colors;
        ThirdPersonController2D PlayerController;
        Camera followCam;
        BroadPhaseWorld world;
        bool loaded = false;

        public InGame(GraphicsContext context)
        {
            context.ResourceManager += LoadResources;
        }

        public IScene Parent
        {
            get;
            set;
        }

        public void Render(double interval, GraphicsContext context)
        {
            context.Clear(0f, 0f, 0f, 1f);
            if (loaded)
            {
                //Box.World = Matrix4.CreateTranslation(-0.5f, -0.25f, 0);
                eBox.Renderable.Materials[0].Shader["inColor"] = Colors[0];
                world.Render(interval, context);
                //eBox.Render(interval, context);
                context.ForceDraw();

                //BoxB.World = Matrix4.CreateTranslation(0, -0.20f, 0f);
                BoxB.Materials[0].Shader["inColor"] = Colors[1];
                BoxB.Draw(context);
                context.ForceDraw();

                Player.Materials[0].Shader["inColor"] = new Vector4(1, 1, 1, 1);
                Player.Draw(context);
            }
            context.SwapBuffers();
        }

        public void Update(double interval, GraphicsContext context)
        {
            if (loaded)
            {
                PlayerController.Update(interval, context);
                Player.World = Matrix4.CreateTranslation(PlayerController.Position);
                context.Camera.Position = PlayerController.Position;

                if (PlayerController.Position.X > -0.25f)
                {
                    Colors[1].X = 1f;
                    Colors[0].X = 0.5f;
                }
                else
                {
                    Colors[0].X = 1f;
                    Colors[1].X = 0.5f;
                }
            }
        }

        public void LoadResources(GraphicsContext context)
        {
            if(world == null)
            {
                world = new BroadPhaseWorld(10, 10);
                world.DrawDistance = 1;
            }

            if (eBox == null)
            {
                eBox = new Entity()
                {
                    ID = 1,
                    Renderable = new Box(0.5f, 0.05f,0.5f),
                    Position = new Vector3(-0.5f, -0.25f, 0),
                    Visible = true
                };
                eBox.Renderable.Materials[0].Shader = Kokoro.ShaderLib.ColorDefaultShader.Create();
                world.Add(eBox);
            }

            if (BoxB == null)
            {
                BoxB = new Box(0.5f, 0.05f, 0.5f);
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
                Player = new Sphere(0.025f, 20);
                Player.Materials[0].Shader = Kokoro.ShaderLib.ColorDefaultShader.Create();

                PlayerController = new ThirdPersonController2D(Vector3.Zero);
                PlayerController.MoveSpeed = 0.1f;
            }

            if (followCam == null)
            {
                followCam = new FollowPointCamera();
                context.Camera = followCam;
            }

            loaded = true;
        }
    }
}
