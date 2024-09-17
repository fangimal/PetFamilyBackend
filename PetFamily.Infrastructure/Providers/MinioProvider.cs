﻿using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using PetFamily.Application.Providers;
using PetFamily.Domain.Common;

namespace PetFamily.Infrastructure.Providers;

public class MinioProvider : IMinioProvider
{
    private const string PhotoBucket = "images";

    private readonly IMinioClient _minioClient;
    private readonly ILogger<MinioProvider> _logger;

    public MinioProvider(IMinioClient minioClient, ILogger<MinioProvider> logger)
    {
        _minioClient = minioClient;
        _logger = logger;
    }

    public async Task<Result<string>> UploadPhoto(Stream stream, string path, CancellationToken ct)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(PhotoBucket);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, ct);

            if (bucketExist == false)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(PhotoBucket);

                await _minioClient.MakeBucketAsync(makeBucketArgs, ct);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(PhotoBucket)
                .WithStreamData(stream)
                .WithObjectSize(stream.Length)
                .WithObject(path);

            var response = await _minioClient.PutObjectAsync(putObjectArgs, ct);

            return response.ObjectName;
        }
        catch (Exception e)
        {
            _logger.LogError("Error while saving file in minio: {message}", e.Message);
            return Errors.General.SaveFailure("photo");
        }
    }

    public async Task<Result> RemovePhoto(string path, CancellationToken ct)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(PhotoBucket);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, ct);

            if (bucketExist == false)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(PhotoBucket);

                await _minioClient.MakeBucketAsync(makeBucketArgs, ct);
            }

            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(PhotoBucket)
                .WithObject(path);

            await _minioClient.RemoveObjectAsync(removeObjectArgs, ct);

            return Result.Success();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Errors.General.SaveFailure("photo");
        }
    }

    public async Task<Result> RemovePhotos(List<string> paths, CancellationToken ct)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(PhotoBucket);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, ct);

            if (bucketExist == false)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(PhotoBucket);

                await _minioClient.MakeBucketAsync(makeBucketArgs, ct);
            }

            var removeObjectsArgs = new RemoveObjectsArgs()
                .WithBucket(PhotoBucket)
                .WithObjects(paths);

            await _minioClient.RemoveObjectsAsync(removeObjectsArgs, ct);

            return Result.Success();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Errors.General.SaveFailure("photo");
        }
    }

    public async Task<Result<IReadOnlyList<string>>> GetPhotos(IEnumerable<string> paths, CancellationToken ct)
    {
        try
        {
            List<string> urls = [];

            foreach (var path in paths)
            {
                var presignedGetObjectArgs = new PresignedGetObjectArgs()
                    .WithBucket(PhotoBucket)
                    .WithObject(path)
                    .WithExpiry(60 * 60 * 24);

                var url = await _minioClient.PresignedGetObjectAsync(presignedGetObjectArgs);
                urls.Add(url);
            }

            return urls;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Errors.General.SaveFailure("photo");
        }
    }

    public IObservable<Item> GetObjectsList(CancellationToken ct)
    {
        var listObjectArgs = new ListObjectsArgs().WithBucket(PhotoBucket);

        return _minioClient.ListObjectsAsync(listObjectArgs, ct);
    }
}