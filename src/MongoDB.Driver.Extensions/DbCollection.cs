// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	DbCollection
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/27 下午9:22
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/27 下午9:22
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoDB.Driver
{
    /// <summary>
    /// 数据集合 
    /// </summary>
    public class DbCollection<TDocument> : IMongoCollection<TDocument>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DbCollection() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mongoClientSettings">mongo客户端配置</param>
        public DbCollection(MongoClientSettings mongoClientSettings)
        {
            this.MongoClientSettings = mongoClientSettings;
            this.MongoClient = new MongoClient(mongoClientSettings);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mongoClientSettings">mongo客户端配置</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">文档集合名称</param>
        public DbCollection(MongoClientSettings mongoClientSettings, string dbName, string collectionName) : this(mongoClientSettings)
        {
            this.DataBaseName = dbName;
            this._collectionNamespace = new CollectionNamespace(dbName, collectionName);

        }

        /// <summary>
        /// mongo客户端配置
        /// </summary>
        protected MongoClientSettings MongoClientSettings { get; private set; }

        /// <summary>
        /// mongo客户端
        /// </summary>
        protected MongoClient MongoClient { get; private set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string DataBaseName { get; private set; }

        /// <summary>
        /// 集合命名空间
        /// </summary>
        public CollectionNamespace CollectionNamespace => this._collectionNamespace ?? this.GetCollectionNamespace();

        /// <summary>
        /// 集合命名空间
        /// </summary>
        private CollectionNamespace _collectionNamespace { get; set; }

        /// <summary>
        /// 获取集合命名空间
        /// </summary>
        /// <returns></returns>
        protected virtual CollectionNamespace GetCollectionNamespace()
        {
            CollectionNameAttribute attribute = typeof(TDocument).GetCustomAttribute<CollectionNameAttribute>();
            if (attribute is null)
                return new CollectionNamespace(this.DataBaseName, typeof(TDocument).Name);
            return new CollectionNamespace(this.DataBaseName, attribute.Name);
        }

        /// <summary>
        /// 文档集合
        /// </summary>
        protected IMongoCollection<TDocument> MongoCollection => this.Database.GetCollection<TDocument>(this.CollectionNamespace.CollectionName);

        /// <summary>
        /// 数据库
        /// </summary>
        public IMongoDatabase Database => this.MongoClient.GetDatabase(this.DataBaseName);

        /// <summary>
        /// 文档序列化器
        /// </summary>
        public IBsonSerializer<TDocument> DocumentSerializer => this.MongoCollection.DocumentSerializer;

        /// <summary>
        /// 文档索引
        /// </summary>
        public IMongoIndexManager<TDocument> Indexes => this.MongoCollection.Indexes;

        /// <summary>
        /// 文档配置设置
        /// </summary>
        public MongoCollectionSettings Settings => throw new NotImplementedException();

        public IAsyncCursor<TResult> Aggregate<TResult>(PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Aggregate(pipeline, options, cancellationToken);

        public IAsyncCursor<TResult> Aggregate<TResult>(IClientSessionHandle session, PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Aggregate(session, pipeline, options, cancellationToken);

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.AggregateAsync(pipeline, options, cancellationToken);

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(IClientSessionHandle session, PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.AggregateAsync(session, pipeline, options, cancellationToken);


        public BulkWriteResult<TDocument> BulkWrite(IEnumerable<WriteModel<TDocument>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.BulkWrite(requests, options, cancellationToken);

        public BulkWriteResult<TDocument> BulkWrite(IClientSessionHandle session, IEnumerable<WriteModel<TDocument>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.BulkWrite(session, requests, options, cancellationToken);

        public Task<BulkWriteResult<TDocument>> BulkWriteAsync(IEnumerable<WriteModel<TDocument>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.BulkWriteAsync(requests, options, cancellationToken);

        public Task<BulkWriteResult<TDocument>> BulkWriteAsync(IClientSessionHandle session, IEnumerable<WriteModel<TDocument>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.BulkWriteAsync(session, requests, options, cancellationToken);

        public long Count(FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Count(filter, options, cancellationToken);

        public long Count(IClientSessionHandle session, FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Count(session, filter, options, cancellationToken);

        public Task<long> CountAsync(FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.CountAsync(filter, options, cancellationToken);

        public Task<long> CountAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.CountAsync(session, filter, options, cancellationToken);

        public long CountDocuments(FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.CountDocuments(filter, options, cancellationToken);

        public long CountDocuments(IClientSessionHandle session, FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.CountDocuments(session, filter, options, cancellationToken);

        public Task<long> CountDocumentsAsync(FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.CountDocumentsAsync(filter, options, cancellationToken);

        public Task<long> CountDocumentsAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.CountDocumentsAsync(session, filter, options, cancellationToken);

        public DeleteResult DeleteMany(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteMany(filter, cancellationToken);

        public DeleteResult DeleteMany(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteMany(filter, options, cancellationToken);

        public DeleteResult DeleteMany(IClientSessionHandle session, FilterDefinition<TDocument> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteMany(session, filter, options, cancellationToken);

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteManyAsync(filter, cancellationToken);

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteManyAsync(filter, options, cancellationToken);

        public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteManyAsync(session, filter, options, cancellationToken);

        public DeleteResult DeleteOne(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteOne(filter, cancellationToken);

        public DeleteResult DeleteOne(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteOne(filter, options, cancellationToken);

        public DeleteResult DeleteOne(IClientSessionHandle session, FilterDefinition<TDocument> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteOne(session, filter, options, cancellationToken);

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteOneAsync(filter, cancellationToken);

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteOneAsync(filter, options, cancellationToken);

        public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.DeleteOneAsync(session, filter, options, cancellationToken);

        public IAsyncCursor<TField> Distinct<TField>(FieldDefinition<TDocument, TField> field, FilterDefinition<TDocument> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Distinct(field, filter, options, cancellationToken);

        public IAsyncCursor<TField> Distinct<TField>(IClientSessionHandle session, FieldDefinition<TDocument, TField> field, FilterDefinition<TDocument> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Distinct(session, field, filter, options, cancellationToken);

        public Task<IAsyncCursor<TField>> DistinctAsync<TField>(FieldDefinition<TDocument, TField> field, FilterDefinition<TDocument> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.DistinctAsync(field, filter, options, cancellationToken);

        public Task<IAsyncCursor<TField>> DistinctAsync<TField>(IClientSessionHandle session, FieldDefinition<TDocument, TField> field, FilterDefinition<TDocument> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.DistinctAsync(session, field, filter, options, cancellationToken);

        public long EstimatedDocumentCount(EstimatedDocumentCountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.EstimatedDocumentCount(options, cancellationToken);

        public Task<long> EstimatedDocumentCountAsync(EstimatedDocumentCountOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.EstimatedDocumentCountAsync(options, cancellationToken);

        public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(FilterDefinition<TDocument> filter, FindOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindAsync(filter, options, cancellationToken);

        public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, FindOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindAsync(session, filter, options, cancellationToken);

        public TProjection FindOneAndDelete<TProjection>(FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndDelete(filter, options, cancellationToken);

        public TProjection FindOneAndDelete<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndDelete(session, filter, options, cancellationToken);

        public Task<TProjection> FindOneAndDeleteAsync<TProjection>(FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndDeleteAsync(filter, options, cancellationToken);

        public Task<TProjection> FindOneAndDeleteAsync<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndDeleteAsync(session, filter, options, cancellationToken);

        public TProjection FindOneAndReplace<TProjection>(FilterDefinition<TDocument> filter, TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndReplace(filter, replacement, options, cancellationToken);

        public TProjection FindOneAndReplace<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndReplace(session, filter, replacement, options, cancellationToken);

        public Task<TProjection> FindOneAndReplaceAsync<TProjection>(FilterDefinition<TDocument> filter, TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.FindOneAndReplaceAsync(filter, replacement, options, cancellationToken);

        public Task<TProjection> FindOneAndReplaceAsync<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.FindOneAndReplaceAsync(session, filter, replacement, options, cancellationToken);

        public TProjection FindOneAndUpdate<TProjection>(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndUpdate(filter, update, options, cancellationToken);

        public TProjection FindOneAndUpdate<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndUpdate(session, filter, update, options, cancellationToken);

        public Task<TProjection> FindOneAndUpdateAsync<TProjection>(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndUpdateAsync(filter, update, options, cancellationToken);

        public Task<TProjection> FindOneAndUpdateAsync<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindOneAndUpdateAsync(session, filter, update, options, cancellationToken);

        public IAsyncCursor<TProjection> FindSync<TProjection>(FilterDefinition<TDocument> filter, FindOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindSync(filter, options, cancellationToken);

        public IAsyncCursor<TProjection> FindSync<TProjection>(IClientSessionHandle session, FilterDefinition<TDocument> filter, FindOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.FindSync(session, filter, options, cancellationToken);

        public void InsertMany(IEnumerable<TDocument> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertMany(documents, options, cancellationToken);

        public void InsertMany(IClientSessionHandle session, IEnumerable<TDocument> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertMany(session, documents, options, cancellationToken);

        public Task InsertManyAsync(IEnumerable<TDocument> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertManyAsync(documents, options, cancellationToken);

        public Task InsertManyAsync(IClientSessionHandle session, IEnumerable<TDocument> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertManyAsync(session, documents, options, cancellationToken);

        public void InsertOne(TDocument document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertOne(document, options, cancellationToken);

        public void InsertOne(IClientSessionHandle session, TDocument document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertOne(session, document, options, cancellationToken);

        public Task InsertOneAsync(TDocument document, CancellationToken _cancellationToken)
            => this.MongoCollection.InsertOneAsync(document, _cancellationToken);

        public Task InsertOneAsync(TDocument document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertOneAsync(document, options, cancellationToken);

        public Task InsertOneAsync(IClientSessionHandle session, TDocument document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.InsertOneAsync(session, document, options, cancellationToken);

        public IAsyncCursor<TResult> MapReduce<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<TDocument, TResult> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.MapReduce(map, reduce, options, cancellationToken);

        public IAsyncCursor<TResult> MapReduce<TResult>(IClientSessionHandle session, BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<TDocument, TResult> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.MapReduce(session, map, reduce, options, cancellationToken);

        public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<TDocument, TResult> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.MapReduceAsync(map, reduce, options, cancellationToken);

        public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(IClientSessionHandle session, BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<TDocument, TResult> options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.MapReduceAsync(session, map, reduce, options, cancellationToken);

        public IFilteredMongoCollection<TDerivedDocument> OfType<TDerivedDocument>() where TDerivedDocument : TDocument
            => this.MongoCollection.OfType<TDerivedDocument>();

        public ReplaceOneResult ReplaceOne(FilterDefinition<TDocument> filter, TDocument replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOne(filter, replacement, options, cancellationToken);

        public ReplaceOneResult ReplaceOne(FilterDefinition<TDocument> filter, TDocument replacement, UpdateOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOne(filter, replacement, options, cancellationToken);

        public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<TDocument> filter, TDocument replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOne(session, filter, replacement, options, cancellationToken);

        public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<TDocument> filter, TDocument replacement, UpdateOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOne(session, filter, replacement, options, cancellationToken);

        public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<TDocument> filter, TDocument replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOneAsync(filter, replacement, options, cancellationToken);

        public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<TDocument> filter, TDocument replacement, UpdateOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOneAsync(filter, replacement, options, cancellationToken);

        public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, TDocument replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOneAsync(session, filter, replacement, options, cancellationToken);

        public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, TDocument replacement, UpdateOptions options, CancellationToken cancellationToken = default)
            => this.MongoCollection.ReplaceOneAsync(session, filter, replacement, options, cancellationToken);

        public UpdateResult UpdateMany(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateMany(filter, update, options, cancellationToken);

        public UpdateResult UpdateMany(IClientSessionHandle session, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateMany(session, filter, update, options, cancellationToken);

        public Task<UpdateResult> UpdateManyAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateManyAsync(filter, update, options, cancellationToken);

        public Task<UpdateResult> UpdateManyAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateManyAsync(session, filter, update, options, cancellationToken);

        public UpdateResult UpdateOne(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateOne(filter, update, options, cancellationToken);

        public UpdateResult UpdateOne(IClientSessionHandle session, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateOne(session, filter, update, options, cancellationToken);

        public Task<UpdateResult> UpdateOneAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateOneAsync(filter, update, options, cancellationToken);

        public Task<UpdateResult> UpdateOneAsync(IClientSessionHandle session, FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.UpdateOneAsync(session, filter, update, options, cancellationToken);

        public IChangeStreamCursor<TResult> Watch<TResult>(PipelineDefinition<ChangeStreamDocument<TDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Watch(pipeline, options, cancellationToken);

        public IChangeStreamCursor<TResult> Watch<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<TDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Watch(session, pipeline, options, cancellationToken);

        public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(PipelineDefinition<ChangeStreamDocument<TDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.WatchAsync(pipeline, options, cancellationToken);

        public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<TDocument>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.WatchAsync(session, pipeline, options, cancellationToken);

        public IMongoCollection<TDocument> WithReadConcern(ReadConcern readConcern)
            => this.MongoCollection.WithReadConcern(readConcern);

        public IMongoCollection<TDocument> WithReadPreference(ReadPreference readPreference)
            => this.MongoCollection.WithReadPreference(readPreference);

        public IMongoCollection<TDocument> WithWriteConcern(WriteConcern writeConcern)
            => this.MongoCollection.WithWriteConcern(writeConcern);

        public void AggregateToCollection<TResult>(PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.Aggregate<TResult>(pipeline, options, cancellationToken);

        public void AggregateToCollection<TResult>(IClientSessionHandle session, PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.AggregateToCollection<TResult>(session, pipeline, options, cancellationToken);

        public Task AggregateToCollectionAsync<TResult>(PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.AggregateToCollectionAsync<TResult>(pipeline, options, cancellationToken);

        public Task AggregateToCollectionAsync<TResult>(IClientSessionHandle session, PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
            => this.MongoCollection.AggregateToCollectionAsync<TResult>(session, pipeline, options, cancellationToken);
    }
}

