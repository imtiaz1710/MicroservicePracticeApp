namespace Platform.Core.Interfaces;

public interface IBaseRepository<T> : IQueryRepositoryBase<T>, ICommandRepositoryBase<T> where T : class { }
