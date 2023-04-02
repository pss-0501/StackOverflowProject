using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowProject.DomainModels;
using StackOverflowProject.Repositories;
using StackOverflowProject.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;

namespace StackOverflowProject.ServiceLayer
{
    public interface IQuestionsService
    {
        void InsertQuestion(NewQuestionViewModel qvm);
        void UpdateQustionDetails(EditQuestionViewModel qvm);
        void UpdateQustionVotesCount(int qid, int value);
        void UpdateQuestionAnswersCount(int qid, int value);
        void UpdateQuestionViewsCount(int qid, int value);
        void Delete(int qid);
        List<Question> GetQuestions();
        QuestionViewModel GetQuestionByQuestionID(int QuestionID);
    }
    public class QuestionsService : IQuestionsService
    {
        IQuestionRepository qr;

        public QuestionsService()
        {
            qr = new QuestionsRepository();
        }

        public void InsertQuestion(NewQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<NewQuestionViewModel, Question>(qvm);
            qr.InsertQuestion(q);
        }

        public void UpdateQustionDetails(EditQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<EditQuestionViewModel, Question>(qvm);
            qr.UpdateQustionDetails(q);
        }

        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            throw new NotImplementedException();
        }

        

        public void UpdateQustionVotesCount(int qid, int value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int qid)
        {
            throw new NotImplementedException();
        }

        public QuestionViewModel GetQuestionByQuestionID(int QuestionID)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }

        
    }
}
