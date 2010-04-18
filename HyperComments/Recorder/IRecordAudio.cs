namespace HyperComments.Recorder
{
    public interface IRecordAudio
    {
        void Start(string filename);
        void Stop();
    }
}