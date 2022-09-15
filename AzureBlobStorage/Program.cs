using Azure.Storage.Blobs;

try
{
 string connectionString = "DefaultEndpointsProtocol=https;AccountName=abdulazizsfetorage;AccountKey=8g3/m7pC9r3PWBT/+GKQusHg/DMFcQZNi6JDON9acIsDtx5RDXRBxDX8oXS7OxBFH51x6AWuLqPd+AStN4BwZQ==;EndpointSuffix=core.windows.net";

 string containerName = "images";
BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
    //Create a container in bolb storage.
BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName);
    Console.WriteLine("Loading....");
    //get the source file     
    var  files = Directory.GetFiles(@"C:\Users\Abdulaziz\Desktop\Bilder");
 
    foreach (var file in files)
        {
            using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(file)))
            {
                containerClient.UploadBlob(Path.GetFileName(file), stream);
            }
      
        if (file != null)
        {
            Console.WriteLine(file + " Uploaded Success");
        }
    }
  
}catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}