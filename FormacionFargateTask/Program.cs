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
            AmazonS3Client S3Client = new AmazonS3Client();

            try
            {
                S3Client.PutBucketAsync(new PutBucketRequest()
                {
                    BucketName = "formacion-fargate",
                    BucketRegion = S3Region.EUW1
                }).Wait();
            }catch(Exception e)
            {
                Console.WriteLine("El bucket ya existe");
            }

            S3Client.PutObjectAsync(new PutObjectRequest()
            {
                BucketName = "formacion-fargate",
                ContentBody = "texto del fichero",
                ContentType = "text/html; charset=utf-8",
                Key = Guid.NewGuid().ToString()
            }).Wait();

            Console.WriteLine("Archivo creado");
        }
    }
}
