namespace Models
{
    public class ProjectModel
    {
        bool HasChanged = false;
        int Id = -1;
        int ParentId = -1;
        string Name;
        Priority Priority = Priority.NONE;
        bool IsOngoing, IsComplete = false;
        DateOnly? TargetDate;
        public ProjectModel(int id, int parentId, string name, Priority priority, bool isOngoing, bool isComplete, DateOnly? targetDate)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            Priority = priority;
            IsOngoing = isOngoing;
            IsComplete = isComplete;
            TargetDate = targetDate;
        }

        public ProjectModel(string name, Priority priority = Priority.NONE, bool isOngoing = false, bool isComplete = false, DateOnly? targetDate = null)
        {
            Name = name;
            Priority = priority;
            IsOngoing = isOngoing;
            IsComplete = isComplete;
            TargetDate = targetDate;
        }

        public void SetParentId(int parentId)
        {
            ParentId = parentId;
            HasChanged = true;
        }

        public void SetName(string name)
        {
            Name = name;
            HasChanged = true;
        }

        public void SetPriority(Priority priority)
        {
            Priority = priority;
        }

        public void SetIsOngoing(bool isOngoing)
        {
            IsOngoing = isOngoing;
        }

        public void SetIsComplete(bool isComplete)
        {
            IsComplete = isComplete;
        }
    }
}