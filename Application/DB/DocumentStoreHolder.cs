using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DB
{
    // 'DocumentStore' is a main-entry point for client API.
    // It is responsible for managing and establishing connections
    // between your application and RavenDB server/cluster
    // and is capable of working with multiple databases at once.
    // Due to it's nature, it is recommended to have only one
    // singleton instance per application
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Urls = new[] { "http://localhost:8080" },
                    Database = "Northwind"
                };

                return store.Initialize();
            });

        public static IDocumentStore Store => LazyStore.Value;
    }
}
