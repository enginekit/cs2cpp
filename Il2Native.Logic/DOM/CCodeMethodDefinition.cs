﻿namespace Il2Native.Logic.DOM
{
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Reflection.Metadata.Ecma335;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Symbols.Metadata.PE;

    public class CCodeMethodDefinition : CCodeDefinition
    {
        internal CCodeMethodDefinition(IMethodSymbol method, BoundStatementList boundBody)
        {
            this.Method = method;
            this.BoundBody = boundBody;
        }

        public IMethodSymbol Method { get; set; }

        internal BoundStatementList BoundBody { get; set; }

        public override void WriteTo(IndentedTextWriter itw, WriteSettings settings)
        {
            itw.WriteLine();

            itw.WriteLine("// Method: {0}", this.Method.ToDisplayString());

            // pre attributes
            // TODO:
            itw.Write("static ");

            CCodeSerializer.WriteMethodDeclaration(itw, settings, this.Method, false);

            CCodeSerializer.WriteMethodBody(itw, this.BoundBody);
        }
    }
}
