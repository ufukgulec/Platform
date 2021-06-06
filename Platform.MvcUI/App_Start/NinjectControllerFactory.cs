using Ninject;
using Platform.Business;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Platform.MvcUI.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBusinessBind();
        }

        private void AddBusinessBind()
        {
            this.kernel.Bind<IEntryService>().To<EntryManager>().WithConstructorArgument("entryRepository", new EfEntryRepository());
            this.kernel.Bind<IPersonService>().To<PersonManager>().WithConstructorArgument("personRepository", new EfPersonRepository());
            this.kernel.Bind<ILikeService>().To<LikeManager>().WithConstructorArgument("likeRepository", new EfLikeRepository());
            this.kernel.Bind<IReplyService>().To<ReplyManager>().WithConstructorArgument("replyRepository", new EfReplyRepository());
            this.kernel.Bind<ITagService>().To<TagManager>().WithConstructorArgument("tagRepository", new EfTagRepository());
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}