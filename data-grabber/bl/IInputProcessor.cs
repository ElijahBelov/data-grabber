﻿namespace data_grabber.bl
{
    internal interface IInputProcessor
    {
        void Start();

        void Process(FileInfo file);

        void End();
    }
}
