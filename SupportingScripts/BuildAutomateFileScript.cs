using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SupportingScripts
{
    public class BuildAutomateFileScript
    {
        public void BuildFile()
        {
            var files = Directory.GetFiles(@"D:\Dev\PublicRepos\Facebook\Facebook\RobotizeToolbox", "*.cs", SearchOption.AllDirectories);
            var sb = new StringBuilder();
            sb.AppendLine("[");
            foreach (var file in files)
            {
                var relativePath = file.Remove(0, "D:\\Dev\\PublicRepos\\Facebook\\Facebook".Length);
                relativePath = relativePath.Replace("\\", "/");
                var str  = $@"
{{
    ""type"": ""createFile"",
    ""path"": ""{relativePath}""
}},
{{
    ""type"": ""openFile"",
    ""path"": ""{relativePath}""
}},
{{
    ""type"": ""typeTextFromFile"",
    ""path"": ""{relativePath}""
}},
{{
    ""type"": ""wait"",
    ""delay"": 10000
}},";
                sb.AppendLine(str);
            }
            sb.AppendLine("]");
            File.WriteAllText(@"D:\Dev\PublicRepos\Facebook\Facebook\.presentation-buddy\instructions.json", sb.ToString());
        }
    }
}
