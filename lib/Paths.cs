using System;
using System.IO;

namespace Connery.Lib
{
    public static class Paths
    {
        public static string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../.."));
        public static string workspaceRelativePath = Path.Combine(projectDirectory, "workspace");
        public static string modelPath = Path.Combine(workspaceRelativePath, "MLModel.zip");
        public static string assetsRelativePath = Path.Combine(projectDirectory, "assets", "img_data");
        public static string testImagesRelativePath = Path.Combine(projectDirectory, "assets", "img_test");
    }
}
