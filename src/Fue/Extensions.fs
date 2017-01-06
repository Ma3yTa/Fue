﻿module internal Fue.Extensions

open HtmlAgilityPack

type HtmlNode with
    member this.TryGetAttribute attr = this.Attributes |> Seq.filter (fun x -> x.Name = attr) |> Seq.tryHead

type HtmlDocument with
    static member ParseNode html =
        let doc = new HtmlDocument()
        // fix for http://stackoverflow.com/questions/293342/htmlagilitypack-drops-option-end-tags
        HtmlNode.ElementsFlags.Remove("option") |> ignore
        doc.LoadHtml(html)
        doc.DocumentNode