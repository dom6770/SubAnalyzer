using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubAnalyzer {
    public string Path { get; set; }
    public SubAnalyzer(string arg) {
        Path = arg;        
    }
    public void Run() {
        Console.WriteLine($"Time: {DateTime.Now.ToString("ddd dd.MM.yyyy HH:mm:ss")}\n");
        Console.Write(Path);
    }
}
