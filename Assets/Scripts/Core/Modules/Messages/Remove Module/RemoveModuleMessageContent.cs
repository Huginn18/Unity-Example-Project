namespace HoodedCrow.Core
{
    public struct RemoveModuleMessageContent: IMessageContent
    {
        public AModuleManager ModuleManager;

        public RemoveModuleMessageContent(AModuleManager moduleManager)
        {
            ModuleManager = moduleManager;
        }
    }
}
