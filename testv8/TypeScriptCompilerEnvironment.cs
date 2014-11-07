// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.IO;
using V8.Net;
using System.Collections.Generic;
using System.Linq;

namespace testv8
{
        public class TypeScriptCompilerEnvironment 
        {
                String tsFile;
                String jsFile;

                public TypeScriptCompilerEnvironment ()
                {
                        this.tsFile = Directory.GetCurrentDirectory () + Path.DirectorySeparatorChar + "HelloWorld.ts";
                        this.jsFile = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "result.js";
                }

                [ScriptMember (inScriptName: "arguments", security: ScriptMemberSecurity.Permanent)]
                public string[] getArguments ()
                {
                        List<string> args = new List<string> ();
                        args.Add ("--target");
                        args.Add ("ES5");
                        args.Add (tsFile);
                        args.Add ("--out");
                        args.Add (jsFile);

                        Console.WriteLine (String.Format("{0} : {1}","arguments", args.Aggregate((a, b) => a + ", " + b)));

                        return args.ToArray();
                }
                        

                [ScriptMember (inScriptName: "newLine", security: ScriptMemberSecurity.Permanent)]
                public string newLine () {
                        return Environment.NewLine; 
                }

                public bool supportsCodePage ()
                {
                        return false;
                }


                [ScriptMember (inScriptName: "readFile", security: ScriptMemberSecurity.Permanent)]
                public string readFile (string path)
                {
                        Console.WriteLine (String.Format("{0},{1}","readFile",path));
                        return  File.ReadAllText (path);
                }

                [ScriptMember (inScriptName: "writeFile", security: ScriptMemberSecurity.Permanent)]
                public void writeFile (string path, string content, bool writeByteOrderMark)
                {
                        Console.WriteLine (String.Format("{0}, path: {1}, content: {2}","writeFile",path,content));
                        File.WriteAllText(path, content);
                }


                public void deleteFile (string path)
                {
                        Console.WriteLine (String.Format("{0},{1}","deleteFile",path));
                }

                [ScriptMember (inScriptName: "fileExists", security: ScriptMemberSecurity.Permanent)]
                public bool fileExists (string path)
                {
                        bool result = File.Exists (path);
                        Console.WriteLine (String.Format("{0},{1},result:{2}","fileExists",path,result));
                        return result;
                }

                [ScriptMember (inScriptName: "directoryExists", security: ScriptMemberSecurity.Permanent)]
                public bool directoryExists (string path)
                {
                        bool result = Directory.Exists (path);
                        Console.WriteLine (String.Format("{0},{1}","directoryExists",path));
                        return result;
                }

                public string[] listFiles (string path, object re, object options)
                {       string[] dummy = {"",""};
                        Console.WriteLine (String.Format("{0},{1},{2},{3}","listFiles",path,re,options));
                        return dummy;
                }

                [ScriptMember (inScriptName: "currentDirectory", security: ScriptMemberSecurity.Permanent)]
                public string currentDirectory ()
                {
                        Console.WriteLine (String.Format("{0}","currentDirectory"));
                        return Directory.GetCurrentDirectory ();
                }


                [ScriptMember (inScriptName: "write", security: ScriptMemberSecurity.Permanent)]
                public void write (string data)
                {      
                        Console.WriteLine (String.Format("{0}",data)); 
                }

                [ScriptMember (inScriptName: "watchFile", security: ScriptMemberSecurity.Permanent)]
                public void watchFile (string filename,string[] options, string callback)
                {
                         Console.WriteLine (String.Format("{0},{1},{2},{3}","watchFile",filename, options, callback));
                }

                [ScriptMember (inScriptName: "resolvePath", security: ScriptMemberSecurity.Permanent)]
                public string resolvePath (string path)
                {
                        Console.WriteLine (String.Format("{0}",path));

                        return Directory.GetCurrentDirectory();
                }

                [ScriptMember (inScriptName: "mkdir", security: ScriptMemberSecurity.Permanent)]
                public void mkdir (string directoryName)
                {
                        Console.WriteLine (String.Format("{0},{1}","directoryExists",directoryName));

                }

                [ScriptMember (inScriptName: "getExecutingFilePath", security: ScriptMemberSecurity.Permanent)]
                public string getExecutingFilePath ()
                {
                        Console.WriteLine (String.Format("{0}","getExecutingFilePath"));
                        return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar ;
                }


                [ScriptMember (inScriptName: "getMemoryUsage", security: ScriptMemberSecurity.Permanent)]
                public string[] getMemoryUsage ()
                {       
                        Console.WriteLine (String.Format("{0}","getMemoryUsage"));
                        string[] dummy = { "", "" };
                        return dummy;
                }

                [ScriptMember (inScriptName: "exitCode", security: ScriptMemberSecurity.Permanent)]
                public void exitCode (int code)
                {
                        Console.WriteLine (String.Format("{0},{1}","exitCode",code));
                }

                [ScriptMember (inScriptName: "garbageCollector", security: ScriptMemberSecurity.Permanent)]
                public void garbageCollector ()
                {

                }

                [ScriptMember (inScriptName: "log", security: ScriptMemberSecurity.Permanent)]
                public void log (string message)
                {       
                        Console.WriteLine (String.Format("{0} : {1} : {2}:",DateTime.Now,"Log", message));
                }
        }
}
