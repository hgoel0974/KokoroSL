using System;

namespace Kokoro.ColladaLL
{

	public partial class Grendgine_Collada_String_Array_String
	{
		public string[] Value(){
			return this.Value_Pre_Parse.Split(' ');
		}		
	}
}
