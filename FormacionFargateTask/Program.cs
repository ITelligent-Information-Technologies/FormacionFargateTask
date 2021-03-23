using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace FormacionFargateTask
{
    class Program
    {

        static void Main(string[] args)
        {
            string nombreBucket = "formacion-batch-sieca";
            string keyFichero = "miPrimerFicheroBatch.txt";
            if (args.Length == 2)
            {
                nombreBucket = args[0];
                keyFichero = args[1];
            }

            AmazonS3Client S3Client = new AmazonS3Client();

            try
            {
                S3Client.PutBucketAsync(new PutBucketRequest()
                {
                    BucketName = nombreBucket,
                    BucketRegion = S3Region.EUW1
                }).Wait();
            }catch(Exception e)
            {
                Console.WriteLine("El bucket ya existe");
            }

            var content = "Hola!! Este es mi primer fichero";

            S3Client.PutObjectAsync(new PutObjectRequest()
            {
                BucketName = nombreBucket,
                ContentBody = content,
                ContentType = "text/html; charset=utf-8",
                Key =keyFichero
            }).Wait();

            Console.WriteLine("Archivo creado");
        }
    }
}
