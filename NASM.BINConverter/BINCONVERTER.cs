using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASM.BINConverter
{
    public class AsmBinConverter
    {
        private bool CheckNASMFolder()
        {
            string nasm_folder = $@"C:\Users\{Environment.UserName}\AppData\Local\bin\NASM"; //NASM Folder
            if (File.Exists(nasm_folder))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ASMToBin(string asm_file, string savetobinorimg)
        {
            if(CheckNASMFolder() == true) //Check NASM Folder, because its needed :D
            {
                ProcessStartInfo asm_to_bin = new ProcessStartInfo();
                asm_to_bin.FileName = "cmd.exe";
                asm_to_bin.Arguments = $"/c nasm -f bin {asm_file} -o {savetobinorimg}"; //Make Sure of ASM File and Converted BIN File Saved in one Folder 
                asm_to_bin.CreateNoWindow = true;
                asm_to_bin.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(asm_file);
            }
            else
            {
                Directory.CreateDirectory(@"C:\NASMBin");
                File.WriteAllText(@"C:\NASMBin\Errors.txt", "Unable to find NASM Folder... PLS Try Install NASM!!!");
            }
        }
    }
}
