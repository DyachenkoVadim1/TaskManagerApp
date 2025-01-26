using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExportClass
{
    public class Exporter
    {
        public void TxtExporter(string path, List<TaskExport> exportList)
        {
            TaskExport taskExport = new TaskExport();
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (TaskExport export in exportList)
                    {
                        string text = $"Наименование: {export.NameTask}\nОписание: {export.DescriptionTask}\nДедлайн: {export.Deadline}\nСтатус выполнения: {(export.NameStatus)}";
                        writer.WriteLine(text);
                    }
                }
            }
            catch { }
        }
        public void jsonExporter(string path, List<TaskExport> tasks)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonString = JsonSerializer.Serialize(tasks, options);

                using (StreamWriter writer = new StreamWriter(path, false, new UTF8Encoding(true)))
                {
                    writer.Write(jsonString);
                }
            }
            catch { }
        }
    }

    public class TaskExport
    {
        public string NameTask { get; set; }
        public string DescriptionTask { get; set; }
        public DateTime? Deadline { get; set; }
        public string NameStatus { get; set; }
    }
}
