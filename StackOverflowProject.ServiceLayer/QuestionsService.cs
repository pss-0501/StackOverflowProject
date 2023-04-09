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
        void DeleteQuestion(int qid);
        List<QuestionViewModel> GetQuestions();
        QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID);
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

        public void UpdateQustionVotesCount(int qid, int value)
        {
            qr.UpdateQustionVotesCount(qid, value);
        }

        public void UpdateQuestionViewsCount(int qid, int value)
        {
            qr.UpdateQuestionViewsCount(qid, value);
        }

        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            qr.UpdateQuestionAnswersCount(qid, value);
        }

        public void DeleteQuestion(int qid)
        {
            qr.DeleteQuestion(qid);
        }        

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> q = qr.GetQuestions();

            //Mapper.CreateMap<Question, QuestionViewModel>()
            //    .ForMember(dest => dest.VirtualProperty, opt => opt.MapFrom(src => src.VirtualProperty))
            //    .ForMember(dest => dest.ForeignKey, opt => opt.MapFrom(src => src.ForeignKey));

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Question, QuestionViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));

                //cfg.CreateMap<Question, QuestionViewModel>(); //cfg.IgnoreUnmapped();
                //cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped();
                //cfg.CreateMap<Category, CategoryViewModel>(); cfg.IgnoreUnmapped();
                //cfg.CreateMap<Answer, AnswerViewModel>(); cfg.IgnoreUnmapped();
                //cfg.CreateMap<Vote, VoteViewModel>(); cfg.IgnoreUnmapped();

                cfg.IgnoreUnmapped(); });

            IMapper mapper = config.CreateMapper();
            var qvm = mapper.Map<List<QuestionViewModel>>(q);  // List<QuestionViewModel> 
            return qvm;
        }

        public QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID = 0)
        {
            Question q = qr.GetQuestionByQuestionID(QuestionID).FirstOrDefault();
            QuestionViewModel qvm = null;
            if (q != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Question, QuestionViewModel>();
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Answer, AnswerViewModel>();
                    cfg.CreateMap<Vote, VoteViewModel>();
                    cfg.IgnoreUnmapped(); });

                IMapper mapper = config.CreateMapper();
                qvm = mapper.Map<Question, QuestionViewModel>(q);

                //foreach (var item in qvm.Answers)
                //{
                //    item.CurrentUserVoteType = 0;
                //    VoteViewModel vote = item.Votes.Where(temp => temp.UserID == UserID).FirstOrDefault();
                //    if (vote != null)
                //    {
                //        item.CurrentUserVoteType = vote.VoteValue;
                //    }
                //}
            }
            return qvm;
        }
    }
}
