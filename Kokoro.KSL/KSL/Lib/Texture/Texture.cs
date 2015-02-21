﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kokoro.KSL.Lib.Math;

#if GLSL
using CodeGenerator = Kokoro.KSL.GLSL.GLSLCodeGenerator;
#if PC
using Kokoro.KSL.GLSL.PC;
#endif
#endif

namespace Kokoro.KSL.Lib.Texture
{
    public static class Texture
    {
        public static Vec4 Read2D(Sampler2D sampler, Vec2 uv)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls( SyntaxTree.FunctionCalls.Tex2D, sampler.ObjName, uv.ObjName)
            };

            SyntaxTree.Variables.Add(k.ObjName, new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            });

            return k;
        }

        public static Vec4 Read1D(Sampler1D sampler, KFloat uv)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Tex1D, sampler.ObjName, uv.ObjName)
            };

            SyntaxTree.Variables.Add(k.ObjName, new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            });

            return k;
        }

        public static Vec4 Read3D(Sampler3D sampler, Vec3 uv)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Tex3D, sampler.ObjName, uv.ObjName)
            };

            SyntaxTree.Variables.Add(k.ObjName, new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            });

            return k;
        }

        //TODO implement gather functions etc
    }
}
