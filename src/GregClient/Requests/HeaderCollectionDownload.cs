﻿using RestSharp;

namespace Greg.Requests
{
    public class HeaderCollectionDownload : Request
    {
        private enum CollectionDownloadType
        {
            ByEngine,
            All
        };

        public static HeaderCollectionDownload All()
        {
            return new HeaderCollectionDownload(CollectionDownloadType.All);
        }

        public static HeaderCollectionDownload ByEngine(string engine)
        {
            return new HeaderCollectionDownload(engine);
        }

        private HeaderCollectionDownload(CollectionDownloadType type)
        {
            this._type = type;
        }

        private HeaderCollectionDownload(string engine)
        {
            this._engine = engine;
            this._type = CollectionDownloadType.ByEngine;
        }

        private string _engine;
        private CollectionDownloadType _type;

        public override string Path
        {
            get
            {
                if (this._type == CollectionDownloadType.ByEngine)
                {
                    return "packages/" + this._engine;
                }
                else // if (this._type == CollectionDownloadType.All)
                {
                    return "packages";
                }
            }
        }

        public override RestSharp.Method HttpMethod
        {
            get { return Method.GET; }
        }

        internal override void Build(ref RestRequest request)
        {
        }
    }
}
