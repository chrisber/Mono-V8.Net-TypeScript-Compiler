using System;
using V8.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Reflection;


namespace testv8
{
        class MainClass
        {

                public static void Main (string[] args)
                {


                       using (var engine = new V8Engine())
                        {
                                string tscJs = File.ReadAllText("tsc.js");
                                engine.RegisterType<string>();
                                engine.RegisterType<bool>();
                                engine.RegisterType<TypeScriptCompilerEnvironment>(null, recursive: true);
                                engine.GlobalObject.SetProperty("monodevelop", new TypeScriptCompilerEnvironment());

                                /// <summary>
                                ///In V8.net How can i compile the script one time and execute it multiple times . 
                                /// It would save my compilation time everytime i call execute 
                                /// Compile .See <a href="https://v8dotnet.codeplex.com/discussions/458793">Excecute compiled script</a>.
                                /// </summary>
                                //compile the tsc.js script
                                var scriptHandle = engine.Compile(tscJs,"Monodevelop.TypeScript.Compiler");
                                //excecute the script with the handler

                                var result = engine.Execute (scriptHandle, "V8.NET Unit Tester");

                                        //var executeFuncHandle = engine.Execute ("(function(monodevelopArgs){ts.executeCommandLine(monodevelopArgs)})","");




                                Console.WriteLine("Value: {0}", result);
                        }







                        Console.WriteLine("Press any key to continue ...");
                        Console.ReadKey(); 
                        Console.WriteLine ("Hello World Finishd!");

                }


  



        }
}
