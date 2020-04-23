using System;
using System.IO;

namespace Connery.Lib
{
    public static class Constants
    {
        public static string ProjectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../.."));
        public static string WorkspaceRelativePath = Path.Combine(ProjectDirectory, "workspace");
        public static string ModelPath = Path.Combine(WorkspaceRelativePath, "MLModel.zip");
        public static string AssetsRelativePath = Path.Combine(ProjectDirectory, "assets", "img_data");
        public static string TestImagesRelativePath = Path.Combine(ProjectDirectory, "assets", "img_test");

        public static string[] Labels = new string[]
        {
            "fresh_apple",
            "fresh_banana",
            "fresh_mango",
            "fresh_orange",
            "rotten_apple",
            "rotten_banana",
            "rotten_mango",
            "rotten_orange"
        };
    }
}
