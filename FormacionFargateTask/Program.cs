using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace FormacionFargateTask
{
    class Program
    {
        private static string _NombreBucket = "formacion-fargate-sieca";
        private static string _KeyFichero = "miPrimerFichero.txt";

        static void Main(string[] args)
        {
            AmazonS3Client S3Client = new AmazonS3Client("AKIA6GBAZF25IMLGHOCW", "6F8UPWedLRqarl3wwwaEmxyozFOWFS3E0azhAoc6");

            try
            {
                S3Client.PutBucketAsync(new PutBucketRequest()
                {
                    BucketName = _NombreBucket,
                    BucketRegion = S3Region.EUW1
                }).Wait();
            }catch(Exception e)
            {
                Console.WriteLine("El bucket ya existe");
            }

            var content = "Hola!! Este es mi primer fichero";

            S3Client.PutObjectAsync(new PutObjectRequest()
            {
                BucketName = _NombreBucket,
                ContentBody = content,
                ContentType = "text/html; charset=utf-8",
                Key =_KeyFichero
            }).Wait();

            Console.WriteLine("Archivo creado");
        }
    }
}
