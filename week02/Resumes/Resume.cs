using System;
using System.Collections.Generic;

public class Resume
{
    public string _firstName;
    public string _lastName;

    public List<Job> _jobs = new List<Job>();

    public Resume()
    {
        
    }

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"\nName: {_lastName} {_firstName}");
        Console.WriteLine("Jobs:");

        for (int i = 0; i < _jobs.Count; i++)
        {
            _jobs[i].DisplayJobDetails();
        }
    }


}