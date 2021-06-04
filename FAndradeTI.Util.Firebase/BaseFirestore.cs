using System;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using Google.Type;
using System.Globalization;
using System.IO;
using System.ServiceModel;

namespace FAndradeTI.Util.Firebase
{
    public class BaseFirestore
    {
        private FirestoreDb db;

        private string json;
        private string projectId;

        private CultureInfo ci;


        protected string Json { get => json; set => json = value; }
        protected string ProjectId { get => projectId; set => projectId = value; }
        public CultureInfo Ci { get => ci; set => ci = value; }

        public BaseFirestore(string json, string projectId)
        {
            Json = json;
            ProjectId = projectId;
            Init();
        }

        private void Init()
        {
            WinReg.SubKey = $"SOFTWARE\\{Application.CompanyName}\\{Application.ProductName}";

            Ci = new CultureInfo("pt-BR");

            var jsonString = File.ReadAllText(Json);
            var builder = new FirestoreClientBuilder { JsonCredentials = jsonString };
            db = FirestoreDb.Create(ProjectId, builder.Build());
        }


        private Query MontarQuery(string path, QueryData[] queryData, string orderBy, SortOrder sortDirection)
        {
            CollectionReference collection = db.Collection(path);

            Query query = collection;

            if (!string.IsNullOrEmpty(orderBy))
            { 
                query = (sortDirection == SortOrder.Ascending) ? collection.OrderBy(orderBy) : collection.OrderByDescending(orderBy);
            }

            if (queryData == null)
                return query;

            foreach (var qd in queryData)
            {
                if (qd.whereName != null && qd.whereValue != null)
                {
                    if (qd.whereValue2 != null)
                    {
                        query = query
                            .WhereGreaterThanOrEqualTo(qd.whereName, ((Date)qd.whereValue).ToDateTime().ToUniversalTime())
                            .WhereLessThan(qd.whereName, ((Date)qd.whereValue2).ToDateTime().ToUniversalTime());
                    }
                    else
                    {
                        query = query.WhereEqualTo(qd.whereName, (string)qd.whereValue);
                    }
                }

            }
            return query;
        }

        public async Task<List<Dictionary<string, object>>> BuscarDadosObject(string path, string docId = null, QueryData[] query = null, string orderBy = "name", SortOrder sortDirection = SortOrder.Ascending)
        {
            var myList = new List<Dictionary<string, object>>();

            QuerySnapshot querySnapshot;

            if (string.IsNullOrEmpty(docId))
            {
                querySnapshot = await MontarQuery(path, query, orderBy, sortDirection).GetSnapshotAsync().ConfigureAwait(true);

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> dic = documentSnapshot.ToDictionary();
                        dic.Add("id", documentSnapshot.Id.ToString(Ci));
                        myList.Add(dic);
                    }
                }
            }
            else
            {
                var documentSnapshot = await db.Collection(path).Document(docId).GetSnapshotAsync().ConfigureAwait(true);

                Dictionary<string, object> dic = documentSnapshot.ToDictionary();
                dic.Add("id", documentSnapshot.Id.ToString(Ci));
                myList.Add(dic);
            }

            return myList;
        }

        public async Task<string> Gravar(string collectionPath, object obj)
        {
            string ret = string.Empty;

            try
            {
                // todo: testar 
                //  var document = await collection.Document().CreateAsync(obj).ConfigureAwait(true);
                // FAA
                CollectionReference collection = db.Collection(collectionPath);
                var document = await collection.AddAsync(obj).ConfigureAwait(true);
                ret = document.Id;
            }
            catch (ProtocolException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
            
        }

        public async Task Gravar(string collectionPath, string documentId, object obj)
        {
            try
            {
                DocumentReference doc = db.Collection(collectionPath).Document(documentId);
                await doc.SetAsync(obj).ConfigureAwait(true);
            }
            catch (ProtocolException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<bool> Atualizar(string collectionPath, string documentId,  object obj)
        {
            var ret = false;

            try
            {
                DocumentReference docRef = db.Collection(collectionPath).Document(documentId);
                await docRef.SetAsync(obj, SetOptions.MergeAll).ConfigureAwait(true);
                ret = true;
            }
            catch (ProtocolException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;

        }
    }
}
