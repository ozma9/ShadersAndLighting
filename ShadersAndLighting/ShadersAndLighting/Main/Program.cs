using System;

namespace ShadersAndLighting
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (LightShade game = new LightShade())
            {
                game.Run();
            }
        }
    }
#endif
}

