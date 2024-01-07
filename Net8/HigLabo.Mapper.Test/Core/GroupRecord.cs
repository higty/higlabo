using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Mapper.Test
{
    public enum GroupViewPermission
    {
        Private,
        Public,
    }
    public class GroupRecord 
    {
        public Guid GroupCD { get; set; }
        public String DisplayName { get; set; }
        public Guid? ParentGroupCD { get; set; }
        public String SearchText { get; set; }
        public User CreateUser { get; set; }
        public Guid CreateUserCD { get; set; }
        public GroupViewPermission ViewPermission { get; set; }
        public String Description { get; set; }

        public List<User> UserList { get; set; } = new List<User>();
        public List<User> NullUserList { get; set; }
    }
    public class GroupRecordChild : GroupRecord
    {
        public new List<User> UserList { get; set; } = new List<User>();
    }

    public class TaskRecord
    {
        public Guid TaskCD { get; set; }
        public String Title { get; set; }
    }
    public class TaskRecordChild : TaskRecord
    {
        public DateTime DueDate { get; set; }
    }
    public class NewsRecord
    {
        public class TaskRecord
        {
            public Guid TaskCD { get; set; }
            public String Title { get; set; }

            public TaskRecord(HigLabo.Mapper.Test.TaskRecord record)
            {
                ObjectMapper.Default.Map(record, this);
            }
        }
    }

    public class ArticleCategoryRecord 
    {
        public Guid CategoryCD { get; set; }
        public String DisplayName { get; set; }
        public Double Ordinal { get; set; }
        public Guid? ParentCategoryCD { get; set; }
        public ArticleCategoryRecord ParentCategory { get; set; }
        public Guid ForumCD { get; set; }

        public List<ArticleCategoryRecord> CategoryList { get; private set; } = new List<ArticleCategoryRecord>();
    }
    public class ArticleCategoryRecordChild : ArticleCategoryRecord
    {
        public String FilterData { get; set; }
        public new List<ArticleCategoryRecordChild> CategoryList { get; private set; } = new List<ArticleCategoryRecordChild>();
    }

}
