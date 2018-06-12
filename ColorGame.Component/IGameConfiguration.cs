namespace ColorGame.Component
{
    public interface IGameConfiguration
    {
        int MaxGameLevel { get; set; }
        int MaxColorSpread { get; set; }
        int MinColorSpread { get; set; }
    }
}