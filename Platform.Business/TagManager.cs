using Platform.Dal.Abstract;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Business
{
    public class TagManager : GenericManager<Tag>, ITagService
    {
        ITagRepository _tagRepository;
        //CacheFonksiyon cacheFonksiyon = new CacheFonksiyon();
        public TagManager(ITagRepository tagRepository) : base(tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public bool Delete(int id)
        {
            return Delete(_tagRepository.Get(id));
        }

        public bool Delete(Tag tag)
        {
            return _tagRepository.Remove(tag);
        }

        public List<Tag> PopularTags()
        {
            return _tagRepository.List().Take(5).ToList();
        }

        public List<Tag> List()
        {
            return _tagRepository.List();
        }

        public List<Tag> List(Expression<Func<Tag, bool>> expression)
        {
            return _tagRepository.List(expression);
        }

        public Tag New(Tag tag)
        {
            tag.IsValid = true;
            return _tagRepository.Add(tag);
        }
    }
}
