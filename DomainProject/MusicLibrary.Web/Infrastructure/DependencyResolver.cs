using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Bal.Services;
using MusicLibrary.Dal.Implementations;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Factories.Implementations;
using MusicLibrary.Factories.Interfaces;
using MusicLibrary.Web.Models.Identity;
using Ninject;
using Ninject.Web.Common;

namespace MusicLibrary.Web.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public DependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            _kernel.Bind<IPlaylistFactory>().To<PlaylistFactory>().InRequestScope();
            _kernel.Bind<ITrackFactory>().To<TrackFactory>().InRequestScope();
            _kernel.Bind<IUserFactory>().To<UserFactory>().InRequestScope();

            _kernel.Bind<IPlaylistRepository>().To<PlaylistRepository>().InRequestScope();
            _kernel.Bind<ITrackRepository>().To<TrackRepository>().InRequestScope();
            _kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();

            _kernel.Bind<IPlaylistServices>().To<PlaylistServices>().InRequestScope();
            _kernel.Bind<ITrackServices>().To<TrackServices>().InRequestScope();
            _kernel.Bind<IUserServices>().To<UserServices>().InRequestScope();

            _kernel.Bind<IUserStore<User, int>>().To<UserStore>().InRequestScope();
        }
    }
}