﻿namespace lohost.API.Response
{
    public class DocumentResponse
    {
        public string DocumentPath { get; set; }

        public byte[] DocumentData { get; set; }

        public bool DocumentFound()
        {
            return DocumentData != null;
        }

        public IResponse GetResponse()
        {
            string[] pathParts = DocumentPath.Split('/');

            string ext = Path.GetExtension(pathParts.Last());

            switch (ext.ToLower())
            {
                case ".html":
                    return new HTMLResponse(DocumentData);
                case ".css":
                    return new CSSResponse(DocumentData);
                case ".js":
                    return new JavaScriptResponse(DocumentData);
                case ".ico":
                    return new ICOResponse(DocumentData);
                case ".jpg":
                    return new JPGResponse(DocumentData);
                case ".png":
                    return new PNGResponse(DocumentData);
                case ".gif":
                    return new GIFResponse(DocumentData);
                case ".json":
                    return new JSONResponse(DocumentData);
                default:
                    return new HTMLResponse(DocumentData);
            }
        }
    }
}