﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if GLSL
using CodeGenerator = Kokoro.KSL.GLSL.GLSLCodeGenerator;
#if PC
using Kokoro.KSL.GLSL.PC;
#endif
#endif

namespace Kokoro.KSL.Lib.Math
{
    /// <summary>
    /// Implements globally available Math functions
    /// </summary>
    public class KMath
    {
        #region Cross
        /// <summary>
        /// Calculate the cross product of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The cross product a x b</returns>
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            var k = new Vec3()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Cross3D, a.ObjName, b.ObjName)
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

        /// <summary>
        /// Calculate the cross product of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The cross product a x b</returns>
        public static Vec2 Cross(Vec2 a, Vec2 b)
        {
            var k = new Vec2()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Cross2D, a.ObjName, b.ObjName)
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

        /// <summary>
        /// Calculate the cross product of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The cross product a x b</returns>
        public static Vec4 Cross(Vec4 a, Vec4 b)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Cross4D, a.ObjName, b.ObjName)
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
        #endregion

        #region Normalize
        /// <summary>
        /// Normalize the vector
        /// </summary>
        /// <param name="a">The vector to normalize</param>
        /// <returns>The normalized vector</returns>
        public static Vec2 Normalize(Vec2 a)
        {
            var k = new Vec2()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Normalize2D, a.ObjName)
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

        /// <summary>
        /// Normalize the vector
        /// </summary>
        /// <param name="a">The vector to normalize</param>
        /// <returns>The normalized vector</returns>
        public static Vec3 Normalize(Vec3 a)
        {
            var k = new Vec3()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Normalize3D, a.ObjName)
            };

            SyntaxTree.Variables[k.ObjName] = new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            };

            return k;
        }

        /// <summary>
        /// Normalize the vector
        /// </summary>
        /// <param name="a">The vector to normalize</param>
        /// <returns>The normalized vector</returns>
        public static Vec4 Normalize(Vec4 a)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Normalize4D, a.ObjName)
            };

            SyntaxTree.Variables[k.ObjName] = new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            };

            return k;
        }
        #endregion

        #region Mod
        /// <summary>
        /// Calculate the modulus of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The modulus a % b</returns>
        public static Vec3 Mod(Vec3 a, Vec3 b)
        {
            var k = new Vec3()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Mod, a.ObjName, b.ObjName)
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


        /// <summary>
        /// Calculate the modulus of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The modulus a % b</returns>
        public static Vec2 Mod(Vec2 a, Vec2 b)
        {
            var k = new Vec2()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Mod, a.ObjName, b.ObjName)
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


        /// <summary>
        /// Calculate the modulus of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The modulus a % b</returns>
        public static Vec4 Mod(Vec4 a, Vec4 b)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Mod, a.ObjName, b.ObjName)
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
        #endregion

        #region Clamp
        /// <summary>
        /// Clamp 'a' between 'min' and 'max'
        /// </summary>
        /// <param name="a">The value to clamp</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static KFloat Clamp(KInt a, KInt min, KInt max)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Clamp, a.ObjName, min.ObjName, max.ObjName)
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

        /// <summary>
        /// Clamp 'a' between 'min' and 'max'
        /// </summary>
        /// <param name="a">The value to clamp</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static Vec2 Clamp(Vec2 a, Vec2 min, Vec2 max)
        {
            var k = new Vec2()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Clamp, a.ObjName, min.ObjName, max.ObjName)
            };

            SyntaxTree.Variables[k.ObjName] = new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            };

            return k;
        }

        /// <summary>
        /// Clamp 'a' between 'min' and 'max'
        /// </summary>
        /// <param name="a">The value to clamp</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static Vec3 Clamp(Vec3 a, Vec3 min, Vec3 max)
        {
            var k = new Vec3()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Clamp, a.ObjName, min.ObjName, max.ObjName)
            };

            SyntaxTree.Variables[k.ObjName] = new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            };

            return k;
        }

        /// <summary>
        /// Clamp 'a' between 'min' and 'max'
        /// </summary>
        /// <param name="a">The value to clamp</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static Vec4 Clamp(Vec4 a, Vec4 min, Vec4 max)
        {
            var k = new Vec4()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Clamp, a.ObjName, min.ObjName, max.ObjName)
            };

            SyntaxTree.Variables[k.ObjName] = new SyntaxTree.Variable()
            {
                type = k.GetType(),
                value = null,
                paramType = SyntaxTree.ParameterType.Variable,
                name = k.ObjName
            };

            return k;
        }
        #endregion

        #region Dot
        /// <summary>
        /// Calculate the dot product of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The dot product a . b</returns>
        public static KFloat Dot(Vec3 a, Vec3 b)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Dot, a.ObjName, b.ObjName)
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

        /// <summary>
        /// Calculate the dot product of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The dot product a . b</returns>
        public static KFloat Dot(Vec2 a, Vec2 b)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Dot, a.ObjName, b.ObjName)
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

        /// <summary>
        /// Calculate the dot product of the two vectors
        /// </summary>
        /// <param name="a">Vector a</param>
        /// <param name="b">Vector b</param>
        /// <returns>The dot product a . b</returns>
        public static KFloat Dot(Vec4 a, Vec4 b)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Dot, a.ObjName, b.ObjName)
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
        #endregion

        #region Trig
        /// <summary>
        /// Sine
        /// </summary>
        /// <param name="a">The angle in radians</param>
        /// <returns>The sine of the angle</returns>
        public static KFloat Sin(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Sin, a.ObjName)
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

        /// <summary>
        /// Cosine
        /// </summary>
        /// <param name="a">The angle in radians</param>
        /// <returns>The cosine of the angle</returns>
        public static KFloat Cos(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Cos, a.ObjName)
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

        /// <summary>
        /// Tangent
        /// </summary>
        /// <param name="a">The angle in radians</param>
        /// <returns>The tangent of the angle</returns>
        public static KFloat Tan(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Tan, a.ObjName)
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

        /// <summary>
        /// arcsine
        /// </summary>
        /// <param name="a">The angle in radians</param>
        /// <returns>The arcsine of the angle</returns>
        public static KFloat ASin(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.ASin, a.ObjName)
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

        /// <summary>
        /// arccosine
        /// </summary>
        /// <param name="a">The angle in radians</param>
        /// <returns>The arccosine of the angle</returns>
        public static KFloat ACos(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.ACos, a.ObjName)
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

        /// <summary>
        /// arctangent
        /// </summary>
        /// <param name="a">The angle in radians</param>
        /// <returns>The arctangent of the angle</returns>
        public static KFloat ATan(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.ATan, a.ObjName)
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
        #endregion

        #region Fract
        /// <summary>
        /// Compute the fractional part of the argument
        /// </summary>
        /// <param name="a">The value to evaluate</param>
        /// <returns>The fractional part of a</returns>
        public static KFloat Fract(KFloat a)
        {
            var k = new KFloat()
            {
                ObjName = CodeGenerator.TranslateSDKFunctionCalls(SyntaxTree.FunctionCalls.Fract, a.ObjName)
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
        #endregion

        #region Random
        public KFloat Noise(Vec2 Seed)
        {
            return KMath.Fract(KMath.Sin(KMath.Dot(Seed, new Vec2(12.9898f, 78.233f))) * 43758.5453f);
        }
        #endregion
    }
}
