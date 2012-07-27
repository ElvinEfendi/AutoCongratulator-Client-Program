﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.4952.
// 
#pragma warning disable 1591

namespace Pulsuz_Mesaj.AutoCongratulateServices {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AutoCongratulateServiceBinding", Namespace="http://yoxlama.com/soap/AutoCongratulateService")]
    public partial class AutoCongratulateService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback loginOperationCompleted;
        
        private System.Threading.SendOrPostCallback getUserObjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback createUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback deleteUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback createAutoCongratOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateAutoCongratOperationCompleted;
        
        private System.Threading.SendOrPostCallback deleteAutoCongratOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAutoCongratOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAutoCongratsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AutoCongratulateService() {
            this.Url = global::Pulsuz_Mesaj.Properties.Settings.Default.Pulsuz_Mesaj_AutoCongratulate_AutoCongratulate;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event loginCompletedEventHandler loginCompleted;
        
        /// <remarks/>
        public event getUserObjectCompletedEventHandler getUserObjectCompleted;
        
        /// <remarks/>
        public event createUserCompletedEventHandler createUserCompleted;
        
        /// <remarks/>
        public event updateUserCompletedEventHandler updateUserCompleted;
        
        /// <remarks/>
        public event deleteUserCompletedEventHandler deleteUserCompleted;
        
        /// <remarks/>
        public event createAutoCongratCompletedEventHandler createAutoCongratCompleted;
        
        /// <remarks/>
        public event updateAutoCongratCompletedEventHandler updateAutoCongratCompleted;
        
        /// <remarks/>
        public event deleteAutoCongratCompletedEventHandler deleteAutoCongratCompleted;
        
        /// <remarks/>
        public event getAutoCongratCompletedEventHandler getAutoCongratCompleted;
        
        /// <remarks/>
        public event getAutoCongratsCompletedEventHandler getAutoCongratsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/login", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int login(string username, string password) {
            object[] results = this.Invoke("login", new object[] {
                        username,
                        password});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void loginAsync(string username, string password) {
            this.loginAsync(username, password, null);
        }
        
        /// <remarks/>
        public void loginAsync(string username, string password, object userState) {
            if ((this.loginOperationCompleted == null)) {
                this.loginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnloginOperationCompleted);
            }
            this.InvokeAsync("login", new object[] {
                        username,
                        password}, this.loginOperationCompleted, userState);
        }
        
        private void OnloginOperationCompleted(object arg) {
            if ((this.loginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.loginCompleted(this, new loginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/getUserObject", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public UserObject getUserObject(int userId) {
            object[] results = this.Invoke("getUserObject", new object[] {
                        userId});
            return ((UserObject)(results[0]));
        }
        
        /// <remarks/>
        public void getUserObjectAsync(int userId) {
            this.getUserObjectAsync(userId, null);
        }
        
        /// <remarks/>
        public void getUserObjectAsync(int userId, object userState) {
            if ((this.getUserObjectOperationCompleted == null)) {
                this.getUserObjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetUserObjectOperationCompleted);
            }
            this.InvokeAsync("getUserObject", new object[] {
                        userId}, this.getUserObjectOperationCompleted, userState);
        }
        
        private void OngetUserObjectOperationCompleted(object arg) {
            if ((this.getUserObjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getUserObjectCompleted(this, new getUserObjectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/createUser", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int createUser(UserObject userObject) {
            object[] results = this.Invoke("createUser", new object[] {
                        userObject});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void createUserAsync(UserObject userObject) {
            this.createUserAsync(userObject, null);
        }
        
        /// <remarks/>
        public void createUserAsync(UserObject userObject, object userState) {
            if ((this.createUserOperationCompleted == null)) {
                this.createUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OncreateUserOperationCompleted);
            }
            this.InvokeAsync("createUser", new object[] {
                        userObject}, this.createUserOperationCompleted, userState);
        }
        
        private void OncreateUserOperationCompleted(object arg) {
            if ((this.createUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.createUserCompleted(this, new createUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/updateUser", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int updateUser(UserObject userObject, int userId) {
            object[] results = this.Invoke("updateUser", new object[] {
                        userObject,
                        userId});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void updateUserAsync(UserObject userObject, int userId) {
            this.updateUserAsync(userObject, userId, null);
        }
        
        /// <remarks/>
        public void updateUserAsync(UserObject userObject, int userId, object userState) {
            if ((this.updateUserOperationCompleted == null)) {
                this.updateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateUserOperationCompleted);
            }
            this.InvokeAsync("updateUser", new object[] {
                        userObject,
                        userId}, this.updateUserOperationCompleted, userState);
        }
        
        private void OnupdateUserOperationCompleted(object arg) {
            if ((this.updateUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateUserCompleted(this, new updateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/deleteUser", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public bool deleteUser(int userId) {
            object[] results = this.Invoke("deleteUser", new object[] {
                        userId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void deleteUserAsync(int userId) {
            this.deleteUserAsync(userId, null);
        }
        
        /// <remarks/>
        public void deleteUserAsync(int userId, object userState) {
            if ((this.deleteUserOperationCompleted == null)) {
                this.deleteUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteUserOperationCompleted);
            }
            this.InvokeAsync("deleteUser", new object[] {
                        userId}, this.deleteUserOperationCompleted, userState);
        }
        
        private void OndeleteUserOperationCompleted(object arg) {
            if ((this.deleteUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteUserCompleted(this, new deleteUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/createAutoCongrat" +
            "", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int createAutoCongrat(AutoCongratObject autoCongrat) {
            object[] results = this.Invoke("createAutoCongrat", new object[] {
                        autoCongrat});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void createAutoCongratAsync(AutoCongratObject autoCongrat) {
            this.createAutoCongratAsync(autoCongrat, null);
        }
        
        /// <remarks/>
        public void createAutoCongratAsync(AutoCongratObject autoCongrat, object userState) {
            if ((this.createAutoCongratOperationCompleted == null)) {
                this.createAutoCongratOperationCompleted = new System.Threading.SendOrPostCallback(this.OncreateAutoCongratOperationCompleted);
            }
            this.InvokeAsync("createAutoCongrat", new object[] {
                        autoCongrat}, this.createAutoCongratOperationCompleted, userState);
        }
        
        private void OncreateAutoCongratOperationCompleted(object arg) {
            if ((this.createAutoCongratCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.createAutoCongratCompleted(this, new createAutoCongratCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/updateAutoCongrat" +
            "", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public bool updateAutoCongrat(AutoCongratObject autoCongrat, int bId) {
            object[] results = this.Invoke("updateAutoCongrat", new object[] {
                        autoCongrat,
                        bId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void updateAutoCongratAsync(AutoCongratObject autoCongrat, int bId) {
            this.updateAutoCongratAsync(autoCongrat, bId, null);
        }
        
        /// <remarks/>
        public void updateAutoCongratAsync(AutoCongratObject autoCongrat, int bId, object userState) {
            if ((this.updateAutoCongratOperationCompleted == null)) {
                this.updateAutoCongratOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateAutoCongratOperationCompleted);
            }
            this.InvokeAsync("updateAutoCongrat", new object[] {
                        autoCongrat,
                        bId}, this.updateAutoCongratOperationCompleted, userState);
        }
        
        private void OnupdateAutoCongratOperationCompleted(object arg) {
            if ((this.updateAutoCongratCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateAutoCongratCompleted(this, new updateAutoCongratCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/deleteAutoCongrat" +
            "", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public bool deleteAutoCongrat(int bId) {
            object[] results = this.Invoke("deleteAutoCongrat", new object[] {
                        bId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void deleteAutoCongratAsync(int bId) {
            this.deleteAutoCongratAsync(bId, null);
        }
        
        /// <remarks/>
        public void deleteAutoCongratAsync(int bId, object userState) {
            if ((this.deleteAutoCongratOperationCompleted == null)) {
                this.deleteAutoCongratOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteAutoCongratOperationCompleted);
            }
            this.InvokeAsync("deleteAutoCongrat", new object[] {
                        bId}, this.deleteAutoCongratOperationCompleted, userState);
        }
        
        private void OndeleteAutoCongratOperationCompleted(object arg) {
            if ((this.deleteAutoCongratCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteAutoCongratCompleted(this, new deleteAutoCongratCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/getAutoCongrat", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public AutoCongratObject getAutoCongrat(int bId) {
            object[] results = this.Invoke("getAutoCongrat", new object[] {
                        bId});
            return ((AutoCongratObject)(results[0]));
        }
        
        /// <remarks/>
        public void getAutoCongratAsync(int bId) {
            this.getAutoCongratAsync(bId, null);
        }
        
        /// <remarks/>
        public void getAutoCongratAsync(int bId, object userState) {
            if ((this.getAutoCongratOperationCompleted == null)) {
                this.getAutoCongratOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAutoCongratOperationCompleted);
            }
            this.InvokeAsync("getAutoCongrat", new object[] {
                        bId}, this.getAutoCongratOperationCompleted, userState);
        }
        
        private void OngetAutoCongratOperationCompleted(object arg) {
            if ((this.getAutoCongratCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAutoCongratCompleted(this, new getAutoCongratCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://yoxlama.com/AutoCongratulate/WebServices/autocongrat.php/getAutoCongrats", RequestNamespace="", ResponseNamespace="")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public AutoCongratObject[] getAutoCongrats(int userId) {
            object[] results = this.Invoke("getAutoCongrats", new object[] {
                        userId});
            return ((AutoCongratObject[])(results[0]));
        }
        
        /// <remarks/>
        public void getAutoCongratsAsync(int userId) {
            this.getAutoCongratsAsync(userId, null);
        }
        
        /// <remarks/>
        public void getAutoCongratsAsync(int userId, object userState) {
            if ((this.getAutoCongratsOperationCompleted == null)) {
                this.getAutoCongratsOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAutoCongratsOperationCompleted);
            }
            this.InvokeAsync("getAutoCongrats", new object[] {
                        userId}, this.getAutoCongratsOperationCompleted, userState);
        }
        
        private void OngetAutoCongratsOperationCompleted(object arg) {
            if ((this.getAutoCongratsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAutoCongratsCompleted(this, new getAutoCongratsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://yoxlama.com/soap/AutoCongratulateService")]
    public partial class UserObject {
        
        private string signField;
        
        private string usernameField;
        
        private string passwordField;
        
        private string mobileOperatorField;
        
        private string phoneNumberField;
        
        /// <remarks/>
        public string sign {
            get {
                return this.signField;
            }
            set {
                this.signField = value;
            }
        }
        
        /// <remarks/>
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public string mobileOperator {
            get {
                return this.mobileOperatorField;
            }
            set {
                this.mobileOperatorField = value;
            }
        }
        
        /// <remarks/>
        public string phoneNumber {
            get {
                return this.phoneNumberField;
            }
            set {
                this.phoneNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://yoxlama.com/soap/AutoCongratulateService")]
    public partial class AutoCongratObject {
        
        private int idField;
        
        private string titleField;
        
        private string receiverFullNumberField;
        
        private string messageField;
        
        private int userIdField;
        
        private string birthDateField;
        
        private int wasSentField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string receiverFullNumber {
            get {
                return this.receiverFullNumberField;
            }
            set {
                this.receiverFullNumberField = value;
            }
        }
        
        /// <remarks/>
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public int userId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string birthDate {
            get {
                return this.birthDateField;
            }
            set {
                this.birthDateField = value;
            }
        }
        
        /// <remarks/>
        public int wasSent {
            get {
                return this.wasSentField;
            }
            set {
                this.wasSentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void loginCompletedEventHandler(object sender, loginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class loginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal loginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void getUserObjectCompletedEventHandler(object sender, getUserObjectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getUserObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getUserObjectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UserObject Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UserObject)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void createUserCompletedEventHandler(object sender, createUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class createUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal createUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void updateUserCompletedEventHandler(object sender, updateUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void deleteUserCompletedEventHandler(object sender, deleteUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class deleteUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal deleteUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void createAutoCongratCompletedEventHandler(object sender, createAutoCongratCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class createAutoCongratCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal createAutoCongratCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void updateAutoCongratCompletedEventHandler(object sender, updateAutoCongratCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateAutoCongratCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateAutoCongratCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void deleteAutoCongratCompletedEventHandler(object sender, deleteAutoCongratCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class deleteAutoCongratCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal deleteAutoCongratCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void getAutoCongratCompletedEventHandler(object sender, getAutoCongratCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAutoCongratCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAutoCongratCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AutoCongratObject Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AutoCongratObject)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void getAutoCongratsCompletedEventHandler(object sender, getAutoCongratsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAutoCongratsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAutoCongratsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AutoCongratObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AutoCongratObject[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591