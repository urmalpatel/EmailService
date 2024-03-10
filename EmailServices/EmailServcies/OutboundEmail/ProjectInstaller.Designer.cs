namespace OutboundEmail
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutboundServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.OutboundEmailInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // OutboundServiceProcessInstaller
            // 
            this.OutboundServiceProcessInstaller.Password = null;
            this.OutboundServiceProcessInstaller.Username = null;
            // 
            // OutboundEmailInstaller
            // 
            this.OutboundEmailInstaller.ServiceName = "OutboundEmail";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.OutboundEmailInstaller,
            this.OutboundServiceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller OutboundServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller OutboundEmailInstaller;
    }
}