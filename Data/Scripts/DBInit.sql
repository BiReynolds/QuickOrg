CREATE TABLE Projects (
    Id INTEGER PRIMARY KEY,
    ProjectName TEXT NOT NULL,
    ParentId INTEGER,
    TargetDate TEXT,
    Priority INTEGER DEFAULT 0,
    IsOngoing INTEGER DEFAULT 0,
    IsComplete INTEGER DEFAULT 0
);

CREATE TABLE Tasks (
    Id INTEGER PRIMARY KEY,
    ProjectId INTEGER,
    TaskName TEXT NOT NULL,
    HourEstimate REAL,
    IsComplete INTEGER DEFAULT 0,
    CONSTRAINT fk_Project
    FOREIGN KEY (ProjectId)
    REFERENCES Projects(Id)
);