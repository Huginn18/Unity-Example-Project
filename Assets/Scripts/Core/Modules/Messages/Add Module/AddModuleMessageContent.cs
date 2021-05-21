namespace HoodedCrow.Core
{
    public struct AddModuleMessageContent: IMessageContent
    {
        public AModuleManager ModuleManager;

        public AddModuleMessageContent(AModuleManager moduleManager)
        {
            ModuleManager = moduleManager;
        }
    }
}
