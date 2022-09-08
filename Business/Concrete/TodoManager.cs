using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TodoManager : ITodoService
    {
        ITodoDal _todoDal;
        public TodoManager(ITodoDal todoDal)
        {
            _todoDal = todoDal;
        }

        public IResult Add(Todo todo)
        {
            _todoDal.Add(todo);
            return new SuccessResult("Eklendi.");
        }

        public IResult Delete(Todo todoId)
        {
            _todoDal.Delete(todoId);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<Todo>> GetAll()
        {
            return new SuccessDataResult<List<Todo>>(_todoDal.GetAll());
        }

        public IDataResult<Todo> GetById(int todoId)
        {
            return new SuccessDataResult<Todo>(_todoDal.Get(t => t.Id == todoId));
        }

        public IResult Update(Todo todo)
        {
            _todoDal.Update(todo);
            return new SuccessResult("Güncellendi");
        }
    }
}
