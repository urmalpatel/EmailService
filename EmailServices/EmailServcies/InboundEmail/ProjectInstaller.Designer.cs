namespace InboundEmail
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
            this.InboundServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.InboundEmailInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // InboundServiceProcessInstaller
            // 
            this.InboundServiceProcessInstaller.Password = null;
            this.InboundServiceProcessInstaller.Username = null;
            // 
            // InboundEmailInstaller
            // 
            this.InboundEmailInstaller.ServiceName = "InboundEmail";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.InboundServiceProcessInstaller,
            this.InboundEmailInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller InboundServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller InboundEmailInstaller;
    }
}