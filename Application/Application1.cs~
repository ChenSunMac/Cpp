using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using CEOModel;
using CMSModel;
using CeoBll.DataAccess;
using CeoBll.Models;
using CeoBll.Indexing;
using CeoBll.Utilities;
using InternPosting = CEOModel.InternPosting;
using DocumentFormat.OpenXml.Packaging;
using ceo_liveNewPostingsModel;

public partial class registrants_internship_postings_postingApplication : System.Web.UI.Page
{
    /// <summary>
    /// Gets or sets a value indicating whether this instance is primary.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is primary; otherwise, <c>false</c>.
    /// </value>
    /// 

    public Int64 postingId
    {
        get
        {
            if (Request.Params["id"] != null)
            {
                try
                {
                    return Convert.ToInt64(Request.Params["id"]);
                }
                catch (Exception)
                {
                    // Invalid id was passed, redirect back
                    Response.Redirect("/registrants/internship-postings/");
                }
            }

            return 0;
        }
    }


    public bool IsPrimary
    {
        get
        {
            if (ViewState["IsPrimary"] != null)
                return bool.Parse(ViewState["IsPrimary"].ToString());
            else
                return false;
        }
        set
        {
            ViewState["IsPrimary"] = value;
        }
    }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        MessageControl.Visible = false;
        pnlUpload.Style.Clear();
        PanelUploadC.Style.Clear();

        if (resumeType.SelectedValue == "UR")
        {
            pnlUpload.Style.Add("display","block");
            pnlBuilder.Style.Add("display", "none");
        }
        else if(resumeType.SelectedValue == "RB")
        {
            pnlBuilder.Style.Add("display", "block");
            pnlUpload.Style.Add("display", "none");
        }
        else
        {
            pnlBuilder.Style.Add("display", "none");
            pnlUpload.Style.Add("display", "none");
        }

        if (coverType.SelectedValue == "UR")
        {
            PanelUploadC.Style.Add("display", "block");
            PanelBuilderC.Style.Add("display", "none");
        }
        else if (coverType.SelectedValue == "RB")
        {
            PanelBuilderC.Style.Add("display", "block");
            PanelUploadC.Style.Add("display", "none");
        }
        else
        {
            PanelBuilderC.Style.Add("display", "none");
            PanelUploadC.Style.Add("display", "none");
        }

        if (!IsPostBack)
        {
            SetFormValues();
        }

        SetEditors();
    }

    
    /// <summary>
    /// Sets the editors.
    /// </summary>
    private void SetEditors()
    {
        txtCoverLetter.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        careerObjective.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        skills.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        education.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        workExperience.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        professionalQualifications.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        awardsAchievements.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        affiliations.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        volunteerWork.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        interests.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};

        additionalInformation.config.toolbar = new object[]
		{
			new object[] { "Bold", "Italic", "Underline", "-", "Subscript", "Superscript", "-", "NumberedList", "BulletedList" },
            new object[] { "Outdent", "Indent", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
			new object[] { "Cut", "Copy", "PasteText", "PasteFromWord", "-", "SpellChecker", "Undo", "Redo" }
		};
    }


    private void SetFormValues()
    {
        var context = new CeoContext();
        var posting = context.Postings.SingleOrDefault(p => p.PostingId == postingId);
        using (var cnx = new CeoEntities())
        {
            //if (Session["SELECTED_POSTING"] != null)
            //{
            if (posting != null)
            {
                
                long pi = Convert.ToInt32(postingId);
                var cxtP = new ceo_liveNewPostingEntities();
                var selectedPosting = cxtP.postings.Where(h => h.postingId == pi).FirstOrDefault();

                if (selectedPosting.status != "open")
                {
                    Response.Write("This posting is closed");
                    Response.Redirect("/registrants/internship-postings/");
                }

                if(postingId != 0){
                    if (Convert.ToInt64(postingId) != selectedPosting.postingId)
                    {
                        long rPostingId = Convert.ToInt64(postingId);
                        var realPosting = cnx.Postings.Where(h => h.postingId == rPostingId).FirstOrDefault();
                      
                    }
                }

                if (selectedPosting != null)
                {
                    Hosts host = cnx.Hosts.FirstOrDefault<Hosts>(h => h.hostId == selectedPosting.hostId);

                    lblJobTitle.Text = string.Format("{0}", selectedPosting.jobTitle);
                    lblPostingId.Text = string.Format("{0}", selectedPosting.postingId);

                    lblOrganization.Text = host.companyName;

                    string imgUrl = cnx.Hosts.FirstOrDefault<Hosts>(h => h.hostId == posting.HostId).mediumLogo;
                    string physicalLocation = "/docs/employer-logos/";
                    Hosts hostlogo = cnx.Hosts.FirstOrDefault<Hosts>(h => h.hostId == host.hostId);
                    if (hostlogo != null)
                    {
                        if (!string.IsNullOrEmpty(hostlogo.mediumLogo))
                        {
                            imgUrl = hostlogo.mediumLogo.ToString();
                        }
                    }

                    imgLogo.ImageUrl = physicalLocation + imgUrl;
                    imgLogo.AlternateText = string.Format("You are applying to a paid internship opportunity available at {0}", host.companyName);

                    //-- if the posting has statements then display the statements and fill the statement labels
                    if (!string.IsNullOrEmpty(selectedPosting.statement1) ||
                        !string.IsNullOrEmpty(selectedPosting.statement2) ||
                        !string.IsNullOrEmpty(selectedPosting.statement3) ||
                        !string.IsNullOrEmpty(selectedPosting.statement4))
                    {
                        pnlStatements.Visible = true;

                        if (!string.IsNullOrEmpty(selectedPosting.statement1))
                        {
                            pnlStatement1.Visible = true;
                            lblStatement1.Text = selectedPosting.statement1;
                        }

                        if (!string.IsNullOrEmpty(selectedPosting.statement2))
                        {
                            pnlStatement2.Visible = true;
                            lblStatement2.Text = selectedPosting.statement2;
                        }

                        if (!string.IsNullOrEmpty(selectedPosting.statement3))
                        {
                            pnlStatement3.Visible = true;
                            lblStatement3.Text = selectedPosting.statement3;
                        }

                        if (!string.IsNullOrEmpty(selectedPosting.statement4))
                        {
                            pnlStatement4.Visible = true;
                            lblStatement4.Text = selectedPosting.statement4;
                        }
                    }

                    //-- Set the question text applicable to this posting
                    bool showNoQuestionPanel = true;
                    if (!string.IsNullOrEmpty(selectedPosting.question1))
                    {
                        Question1Panel.Visible = true;
                        showNoQuestionPanel = false;
                        lblQuestion1.Text = selectedPosting.question1;
                    }

                    if (!string.IsNullOrEmpty(selectedPosting.question2))
                    {
                        Question2Panel.Visible = true;
                        showNoQuestionPanel = false;
                        lblQuestion2.Text = selectedPosting.question2;
                    }

                    if (!string.IsNullOrEmpty(selectedPosting.question3))
                    {
                        Question3Panel.Visible = true;
                        showNoQuestionPanel = false;
                        lblQuestion3.Text = selectedPosting.question3;
                    }

                    NoQuestionsPanel.Visible = showNoQuestionPanel;


                    // Get the currently logged in users details.
                    var loggedInUser = Session["userDetails"] as CEOModel.user_details;

                    if (loggedInUser != null)
                    {
                        //TODO
                        using (var cxt = new CeoEntities())
                        {
                            lblEmail.Text = loggedInUser.email;
                          
                            lblCellPhone.Text = loggedInUser.phone + "<br />";
                            lblAddress1.Text = loggedInUser.address1;
                            lblAddress2.Text = loggedInUser.address2 + "<br />";
                            lblAddress2.Visible = !string.IsNullOrEmpty(loggedInUser.address2);
                            lblCity.Text = loggedInUser.city;
                            
                            lblPostcode.Text = loggedInUser.postalCode;
                        }

                        BindDropDown(loggedInUser);
                    }

                   
                }
            }
        }
    }

    /// <summary>
    /// Loads the resume details.
    /// </summary>
    /// <param name="resume">The resume.</param>
    private void LoadResumeDetails(Resumes resume)
    {
        var regex = new Regex(@"(\r\n|\r|\n)+");

        careerObjective.Text = string.Equals(resume.careerObjective, "<br>") ? string.Empty : regex.Replace(resume.careerObjective, string.Empty);
        skills.Text = string.Equals(resume.skills, "<br>") ? string.Empty : resume.skills;
        education.Text = string.Equals(resume.education, "<br>") ? string.Empty : resume.education;
        workExperience.Text = string.Equals(resume.workExperience, "<br>") ? string.Empty : resume.workExperience;
        professionalQualifications.Text = string.Equals(resume.professionalQualifications, "<br>") ? string.Empty : resume.professionalQualifications;
        awardsAchievements.Text = string.Equals(resume.awardsAchievements, "<br>") ? string.Empty : resume.awardsAchievements;
        affiliations.Text = string.Equals(resume.affiliations, "<br>") ? string.Empty : resume.affiliations;
        volunteerWork.Text = string.Equals(resume.volunteerWork, "<br>") ? string.Empty : resume.volunteerWork;
        interests.Text = string.Equals(resume.interests, "<br>") ? string.Empty : resume.interests;
        additionalInformation.Text = string.Equals(resume.additionalInformation, "<br>") ? string.Empty : resume.additionalInformation;
    }

    /// <summary>
    /// Binds the drop down.
    /// </summary>
    /// <param name="loggedInUser">The logged in user.</param>
    private void BindDropDown(CEOModel.user_details loggedInUser)
    {
        using (var cxt = new CeoEntities())
        {
            var query = (from posting in cxt.Postings
                         join application in cxt.InternPosting
                         on posting.postingId equals application.postingId
                         where application.applicationComplete
                         && application.userId == loggedInUser.userId
                         select posting).ToList();

            var list = query.ToList();

            ddlPostings.DataSource = list;
            ddlPostings.DataTextField = "jobTitle";
            ddlPostings.DataValueField = "postingId";
            ddlPostings.DataBind();

            ddlPostings.Items.Insert(0, new ListItem("-- Please Select --", ""));
        }
    }

    protected void UpdateResume(object sender, EventArgs e)
    {
        if (ddlPostings.SelectedIndex != 0)
        {
            int postingId = int.Parse(ddlPostings.SelectedValue);

            // Get the currently logged in users details.
            var loggedInUser = Session["userDetails"] as CEOModel.user_details;

            if (loggedInUser != null)
            {
                using (var cxt = new CeoEntities())
                {
                    InternPosting application = cxt.InternPosting.FirstOrDefault(ip => ip.userId == loggedInUser.userId && ip.postingId == postingId);

                    if (application != null)
                    {
                        // First we delete the resume associated with the application
                        Resumes resume = cxt.Resumes.FirstOrDefault(r => r.resumeId == application.resumeId);

                        if (resume != null)
                        {
                            LoadResumeDetails(resume);
                        }
                    }
                }
            }
        }
    }

    protected void CancelApplication(object sender, ImageClickEventArgs e)
    {
       //-- the user has opted to cancel thier posting application. Delete any uploaded files and reurn the user to the intern postings page
        if (!string.IsNullOrEmpty(tempFile.Value))
        {
            File.Delete(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), tempFile.Value));
        }
        if (!string.IsNullOrEmpty(tempFileC.Value))
        {
            File.Delete(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), tempFileC.Value));
        }

        Response.Redirect("/registrants/internship-postings/");
    }


    /// <summary>
    /// Collect all of the information in the application form and display it to the user before they submit thier application
    /// Does not index the resume data at this point. If the user has selected to uplaod a resume save the resume to the server
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PreviewApplication(object sender, ImageClickEventArgs e)
    {
        var regex = new Regex(@"(\r\n|\r|\n)+");
        var intern = Session["userDetails"] as CEOModel.user_details;


        var context = new CeoContext();
        var posting = context.Postings.SingleOrDefault(p => p.PostingId == postingId);

        var selectedPosting = posting;

        //-- trim all required field inputs to make sure the user hasn't tried to use a space to get around the required field validators
        TrimRequiredFields();

        //-- make sure to fire all of the validators, but only fire the resume upload or resume builder validators if that option has been selected
        Page.Validate("PostingApplicationGroup");
        Page.Validate(resumeType.SelectedValue == "UR" ? "UploadGroup" : "ResumeGroup");
        Page.Validate(coverType.SelectedValue == "UR" ? "UploadGroupC" : "ResumeGroupC");

        //-- validate that the required fields have been filled in and that the statements and host questions have been asnwered
        if (Page.IsValid)
        {
            FormPanel.Visible = false;
            PreviewPanel.Visible = true;

            Email.Text = lblEmail.Text;
            HomePhone.Text = lblHomePhone.Text;
            CellPhone.Text = lblCellPhone.Text;
            Address1.Text = lblAddress1.Text;
            Address2.Text = lblAddress2.Text;
            City.Text = lblCity.Text;
            Province.Text = lblProvince.Text;
            Postcode.Text = lblPostcode.Text;

            Question1.Text = lblQuestion1.Text;
            lblAnswer1.Text = txtQuestion1.Text;

            Question2.Text = lblQuestion2.Text;
            lblAnswer2.Text = txtQuestion2.Text;

            Question3.Text = lblQuestion3.Text;
            lblAnswer3.Text = txtQuestion3.Text;

            //-- if there are any host statements then display the statement panel
            if (!string.IsNullOrEmpty(selectedPosting.Statement1) ||
                    !string.IsNullOrEmpty(selectedPosting.Statement2) ||
                    !string.IsNullOrEmpty(selectedPosting.Statement3) ||
                    !string.IsNullOrEmpty(selectedPosting.Statement4))
            {
                pnlPreviewStatements.Visible = true;
            }
            else
            {
                pnlPreviewStatements.Visible = false;
            }

            if (!string.IsNullOrEmpty(selectedPosting.Statement1))
            {
                lblStatement1Preview.Text = lblStatement1.Text;
                lblStatementAnsewer1.Text = cbxStatement1.Checked ? "Yes" : "No";
            }

            if (!string.IsNullOrEmpty(selectedPosting.Statement2))
            {
                lblStatement2Preview.Text = lblStatement2.Text;
                lblStatementAnsewer2.Text = cbxStatement2.Checked ? "Yes" : "No";
            }

            if (!string.IsNullOrEmpty(selectedPosting.Statement3))
            {
                lblStatement3Preview.Text = lblStatement3.Text;
                lblStatementAnsewer3.Text = cbxStatement3.Checked ? "Yes" : "No";
            }

            if (!string.IsNullOrEmpty(selectedPosting.Statement4))
            {
                lblStatement4Preview.Text = lblStatement4.Text;
                lblStatementAnsewer4.Text = cbxStatement4.Checked ? "Yes" : "No";
            }

            #region resumeType
            if (resumeType.SelectedValue == "UR")
            {
                pnlUploadPreview.Visible = true;
                pnlBuilderPreview.Visible = false;

                string documentPath;

                //-- if the user wants to use the last resume that was uploaded link to that resume 
                //-- otherwise save the uploaded resume and link to it instead
                //if (cbxUseUploaded.Checked)
                //{
                //    using (var context = new CeoEntities())
                //    {
                //        var internResume =
                //            context.Resumes.Where(r => r.internId == intern.internId && (r.hasUploadedDocument.HasValue && r.hasUploadedDocument.Value))
                //                   .OrderByDescending(r => r.resumeId)
                //                   .First();

                //        documentPath = string.Format("{0}/{1}", ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"], internResume.documentName);
                //    }
                //}
                //else
                //{
                    //-- generate and save a temporary file name
                    var extention = Path.GetExtension(fileResume.PostedFile.FileName);
                    
                    if (string.IsNullOrEmpty(tempFile.Value))
                    {
                        tempFile.Value = string.Format("{0}{1}", Guid.NewGuid().ToString(), extention);
                    }
                    
                    //-- if the user has upload a document previously check to make sure that they haven't uploaded a  different type of document
                    //-- if they have delete the previous file
                    if (extention != Path.GetExtension(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), tempFile.Value)))
                    {
                        File.Delete(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), tempFile.Value));
                        tempFile.Value = string.Format("{0}{1}", Guid.NewGuid().ToString(), extention);
                    }

                    fileResume.SaveAs(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), tempFile.Value));
                    documentPath = string.Format("{0}/{1}", ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"], tempFile.Value);
                //}

                lnkPreviewResume.Target = "_blank";
                lnkPreviewResume.ToolTip = "Open or download a copy of your uploaded resume";
                lnkPreviewResume.NavigateUrl = documentPath;
                lnkPreviewResume.Text = string.Format("{0} {1} Application", intern.firstname, intern.lastname);
            }
            else
            {
                //-- display the contents of the users resume from the resume builder
                pnlBuilderPreview.Visible = true;
                pnlUploadPreview.Visible = false;

                careerOBJ.Text = regex.Replace(careerObjective.Text, string.Empty).Replace("<br />", string.Empty);
                lblSkills.Text = skills.Text;
                edu.Text = education.Text;
                workExp.Text = workExperience.Text;
                qualifications.Text = professionalQualifications.Text;
                awards.Text = awardsAchievements.Text;
                affil.Text = affiliations.Text;
                volunteer.Text = volunteerWork.Text;
                lblInterests.Text = interests.Text;
                additional.Text = additionalInformation.Text;
            }
            #endregion resumeType
            #region coverType
            if (coverType.SelectedValue == "UR")
            {
                pnlUploadCPreview.Visible = true;
                pnlBuilderCPreview.Visible = false;
                string documentPath;

                var extention = Path.GetExtension(fileCover.PostedFile.FileName);

                if (string.IsNullOrEmpty(tempFileC.Value))
                {
                    tempFileC.Value = string.Format("{0}{1}", Guid.NewGuid().ToString(), extention);
                }

                //-- if the user has upload a document previously check to make sure that they haven't uploaded a  different type of document
                //-- if they have delete the previous file
                if (extention != Path.GetExtension(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), tempFile.Value)))
                {
                    File.Delete(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), tempFileC.Value));
                    tempFileC.Value = string.Format("{0}{1}", Guid.NewGuid().ToString(), extention);
                }

                fileCover.SaveAs(string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), tempFileC.Value));
                documentPath = string.Format("{0}/{1}", ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"], tempFileC.Value);
                //}

                lnkPreviewCover.Target = "_blank";
                lnkPreviewCover.ToolTip = "Open or download a copy of your uploaded cover letter";
                lnkPreviewCover.NavigateUrl = documentPath;
                lnkPreviewCover.Text = string.Format("{0} {1} cover letter", intern.firstname, intern.lastname);
            }
            else
            {
                //-- display the contents of the users resume from the resume builder
                pnlUploadCPreview.Visible = false;
                pnlBuilderCPreview.Visible = true;
                lblCoverLetter.Text = txtCoverLetter.Text;
            }
            #endregion coverType
        }
    }

    private void TrimRequiredFields()
    {
        // ReSharper disable ReturnValueOfPureMethodIsNotUsed
        txtCoverLetter.Text.Trim();
        careerObjective.Text.Trim();
        skills.Text.Trim();
        education.Text.Trim();
        workExperience.Text.Trim();
        txtQuestion1.Text.Trim();
        txtQuestion2.Text.Trim();
        txtQuestion3.Text.Trim();
        // ReSharper restore ReturnValueOfPureMethodIsNotUsed
    }

    /// <summary>
    /// Submits the users application to careeredge for review by the host
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void SubmitApplication(object sender, ImageClickEventArgs e)
    {
        var regex = new Regex(@"(\r\n|\r|\n)+");
        var intern = Session["userDetails"] as CEOModel.user_details;
        long applicationId = 0;

        //-- create a resume
        long resumeId =  CreateResume(intern.userId);

        //-- create an application
        applicationId = CreateApplication(intern.userId, resumeId);

        if (coverType.SelectedValue == "UR")
        {
            CreateCoverLetter(applicationId);
        }

        //-- complete application
        CompleteApplication(applicationId);

        //-- index the resume and the application
        IndexResumeandApplication(resumeId, intern.userId);
        
        //-- email intern
        SendInternEmail(applicationId);

        // updateTracking
        trackingCEO.addTrackRecord(intern.userId, applicationId, trackingCEO.internTracking_applyJob, intern.userId, "");

        //-- redirect the user to the success page
        Response.Redirect("~/registrants/internship-postings/applicationSuccess.aspx?id=" + applicationId);
    }

    private void IndexResumeandApplication(long resumeId, long internId)
    {
        using (var context = new CeoEntities())
        {
            var resume = context.Resumes.Single(r => r.resumeId == resumeId);
            var intern = context.user_details.Single(i => i.userId == internId);
            
            var indexer = ResumeIndexer.GetIndexer(Server.MapPath(ConfigurationManager.AppSettings["INDEX_STOP_WORDS"]), Server.MapPath(ConfigurationManager.AppSettings["RESUME_INDEX"]));
            var rawResume = new RawResume
                                {
                                    FirstName = intern.firstname,
                                    LastName = intern.lastname,
                                    AdditionalInformation = resume.additionalInformation,
                                    Affiliations = resume.affiliations,
                                    AwardsAchievements = resume.awardsAchievements,
                                    CareerObjective = resume.careerObjective,
                                    ContactInformation = resume.contactInformation,
                                    CoverLetter = txtCoverLetter.Text,
                                    DateCreated = resume.dateCreated,
                                    Education = resume.education,
                                    Email = intern.email,
                                    Interests = resume.interests,
                                    InternId = internId,
                                    IsPrimary = resume.isPrimary,
                                    LastModified = resume.lastModified,
                                    ProfessionalQualifications = resume.professionalQualifications,
                                    ResumeId = resumeId,
                                    Skills = resume.skills,
                                    VolunteerWork = resume.volunteerWork,
                                    WorkExperience = resume.workExperience
                                };

            indexer.Index(rawResume);
        }
    }

    private long CreateApplication(long internId, long resumeId)
    {
        var context1 = new CeoContext();
        var posting = context1.Postings.SingleOrDefault(p => p.PostingId == postingId);
       
        var selectedPosting = posting;

        using (var context = new CeoEntities())
        {
            Dic_InternPostingStatus status = context.Dic_InternPostingStatus.FirstOrDefault(i => i.internPostingStatusId == (long)InternPostingStatusEnum.ToBeReviewed);

            var application = new InternPosting
                                  {
                                      userId = internId,
                                      useUploadedResume = resumeType.SelectedValue == "UR",
                                      applicationComplete = true,
                                      hostInvite = false,
                                      staffInvite = false,
                                      postingId = selectedPosting.PostingId,
                                      resumeId = resumeId,
                                      coverLetter = txtCoverLetter.Text,
                                      InternPosting_InternPostingStatusReference = {Value = status},
                                      createdByRegistrant = internId,
                                      dateCreated = DateTime.Now,
                                      modifiedByRegistrant = internId,
                                      dateModified = DateTime.Now,
                                      statement1 = cbxStatement1.Checked,
                                      statement2 = cbxStatement2.Checked,
                                      statement3 = cbxStatement3.Checked,
                                      statement4 = cbxStatement4.Checked
                                  };

            if (!string.IsNullOrEmpty(selectedPosting.Question1))
            {
                application.AnswerQuestion1 = txtQuestion1.Text;
            }

            if (!string.IsNullOrEmpty(selectedPosting.Question2))
            {
                application.AnswerQuestion2 = txtQuestion2.Text;
            }

            if (!string.IsNullOrEmpty(selectedPosting.Question3))
            {
                application.AnswerQuestion3 = txtQuestion3.Text;
            }

            context.AddToInternPosting(application);
            context.SaveChanges();

            return application.internPostingId;
        }
    }

    private long CreateResume(long internId)
    {
        var resume = new Resumes { userId = internId, dateCreated = DateTime.Now, hasUploadedDocument = false, isPrimary = true, lastModified = DateTime.Now };
        string extension = string.Empty;
        string documentPath = string.Empty;
        string resumeFilename = string.Empty;
        
        using (var context = new CeoEntities())
        {
            //-- save the resume 
            context.Resumes.AddObject(resume);
            context.SaveChanges();

            //-- check to see what kind of resume the intern want to use
            if (resumeType.SelectedValue == "UR")
            {
                resume.hasUploadedDocument = true;
                var intern = context.user_details.Single(i => i.userId == internId);

                extension = Path.GetExtension(tempFile.Value).ToLower();
                var tempFilename = tempFile.Value;
                string fullNameFile = string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), tempFilename);
                string originalFileName = string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), tempFilename);

                if (extension != ".pdf")
                {
                    //string ex = Path.GetExtension(fileResume.PostedFile.FileName).ToLower(); ;
                    PdfWatermarker.ConvertToPdf(fullNameFile, fullNameFile.Replace(extension, ".pdf"));
                    fullNameFile = fullNameFile.Replace(extension, ".pdf");
                }

               // resume.careerObjective = PdfExtractor.Extract(fullNameFile, ConfigurationManager.AppSettings["BCL_LICENSE"]);
                string resumeName = string.Format("{0} {1}-{2}-{3}.pdf", intern.firstname, intern.lastname, internId, resume.resumeId);
                resumeFilename = string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["RESUME_UPLOAD_PATH"]), resumeName);

               //PdfWatermarker.Watermark(originalFileName,
               //                                 resumeFilename,
               //                                 false,
               //                                 Server.MapPath(ConfigurationManager.AppSettings["WATERMARK"]),
               //                                 ConfigurationManager.AppSettings["BCL_LICENSE"],
               //                                 extension.Substring(1) != "pdf");
               //// File.
                //File.Delete(fullNameFile);
                resume.documentName = resumeName;
                
            }
            else
            {
                resume.careerObjective = careerObjective.Text;
                resume.skills = skills.Text;
                resume.education = education.Text;
                resume.workExperience = workExperience.Text;
                resume.professionalQualifications = professionalQualifications.Text;
                resume.awardsAchievements = awardsAchievements.Text;
                resume.affiliations = affiliations.Text;
                resume.volunteerWork = volunteerWork.Text;
                resume.interests = interests.Text;
                resume.additionalInformation = additionalInformation.Text;
            }

            context.SaveChanges();
        }

        return resume.resumeId;
    }

    private void CreateCoverLetter(long applicationId)
    {
        var coverletter = new coverletter { applicationId = applicationId, dateCreated = DateTime.Now };
        string extension = string.Empty;
        string documentPath = string.Empty;
        string coverFilename = string.Empty;
        string coveletterS = string.Empty;
        using (var context = new ceo_liveNewPostingEntities())
        {
            //-- save the resume 
            context.coverletters.AddObject(coverletter);
            context.SaveChanges();

            var cxt = new CeoEntities();
            var intern = (from i in cxt.user_details
                          join ip in cxt.InternPosting on i.userId equals ip.userId
                          where ip.internPostingId == applicationId
                          select i).FirstOrDefault();

            extension = Path.GetExtension(tempFileC.Value).ToLower();
            var tempFilename = tempFileC.Value;
            string fullNameFile = string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), tempFilename);
            string originalFileName = string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), tempFilename);

            if (extension != ".pdf")
            {
                //string ex = Path.GetExtension(fileResume.PostedFile.FileName).ToLower(); ;
                PdfWatermarker.ConvertToPdf(fullNameFile, fullNameFile.Replace(extension, ".pdf"));
                fullNameFile = fullNameFile.Replace(extension, ".pdf");
            }

            coveletterS = PdfExtractor.Extract(fullNameFile, ConfigurationManager.AppSettings["BCL_LICENSE"]);
            string resumeName = string.Format("{0} {1}-{2}-{3}.pdf", intern.firstname, intern.lastname, intern.userId, applicationId);
            coverFilename = string.Format(@"{0}\{1}", Server.MapPath(ConfigurationManager.AppSettings["COVERLETTER_UPLOAD_PATH"]), resumeName);

            PdfWatermarker.Watermark(originalFileName,
                                            coverFilename,
                                            false,
                                            Server.MapPath(ConfigurationManager.AppSettings["WATERMARK"]),
                                            ConfigurationManager.AppSettings["BCL_LICENSE"],
                                            extension.Substring(1) != "pdf");
            File.Delete(fullNameFile);

            var internposting = cxt.InternPosting.Where(h => h.internPostingId == applicationId).FirstOrDefault();
            internposting.coverLetter = coveletterS;
            cxt.SaveChanges();

            var coverL = context.coverletters.Where(p => p.applicationId == applicationId).FirstOrDefault();
            coverL.documentName = coverFilename;
            context.SaveChanges();
        }
    }

    protected string TextFromWord(string fileName)
    {
        using (WordprocessingDocument myDocument = WordprocessingDocument.Open(fileName, false))
        {
            //string text = myDocument.MainDocumentPart.Document.InnerText;
            string text = myDocument.MainDocumentPart.Document.InnerXml;
            return text;
        }

    }

    private void CompleteApplication(long id)
    {
        using (var context = new CeoEntities())
        {
            var application = context.InternPosting.SingleOrDefault(a => a.internPostingId == id);
            if (application == null) return;
            application.ipAddress = HttpContext.Current.Request.UserHostAddress;
            application.applicationDate = DateTime.Now;

            context.SaveChanges();
        }
    }

    /// <summary>
    /// Return the user back to the posting application page so that changes can be made to thier resume or to cancel the application process
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ReturnToApplication(object sender, ImageClickEventArgs e)
    {
        FormPanel.Visible = true;
        PreviewPanel.Visible = false;
    }

    /// <summary>
    /// Validates the application form to verify that a user if they've selected to upload a resume that they've either provided 
    /// a resume to upload or are using a previously uploaded resume
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ValidateResumeUpload(object source, ServerValidateEventArgs args)
    {
        if (!fileResume.HasFile )//&& !cbxUseUploaded.Checked)
        {
            args.IsValid = false;
        }
        else
        {
            if (!fileResume.HasFile)// && cbxUseUploaded.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                if (fileResume.HasFile)
                {
                    //-- make sure that the file being uploaded is the correct format
                    var extention = Path.GetExtension(fileResume.PostedFile.FileName);

                    if (extention == ".doc" || extention == ".docx" || extention == ".txt" || extention == ".pdf" ||
                        extention == ".rtf")
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }
    }

    protected void ValidateCoverUpload(object source, ServerValidateEventArgs args)
    {
        if (!fileCover.HasFile)//&& !cbxUseUploaded.Checked)
        {
            args.IsValid = false;
        }
        else
        {
            if (!fileCover.HasFile)// && cbxUseUploaded.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                if (fileCover.HasFile)
                {
                    //-- make sure that the file being uploaded is the correct format
                    var extention = Path.GetExtension(fileCover.PostedFile.FileName);

                    if (extention == ".doc" || extention == ".docx" || extention == ".txt" || extention == ".pdf" ||
                        extention == ".rtf")
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }
    }
    private void SendInternEmail(Int64 applicationId)
    {
        var loggedInUser = Session["userDetails"] as CEOModel.user_details;

        var context = new CeoContext();
        var posting = context.Postings.SingleOrDefault(p => p.PostingId == postingId);


        if (loggedInUser != null)
        {
            if (posting != null)
            {
                var selectedPosting = posting;

                if (selectedPosting != null)
                {
                    using (var cxt = new CeoEntities())
                    {
                        string subject = null;
                        string emailContent = null;
                        string from = null;
                        string emailCode = "CAREER_EDGE_POSTING_APPLICATION";
                        string atsURL = null;

                        using (var cmscxt = new CMSModelContainer())
                        {
                            Hosts host = cxt.Hosts.FirstOrDefault(h => h.hostId == selectedPosting.HostId);
                            if (!string.IsNullOrEmpty(host.allowATS.ToString()))
                            {
                                var cxtPosting = new ceo_liveNewPostingEntities();
                                var atsUrl = cxtPosting.hosts_postings_passthrough.Where(h => h.postingId == selectedPosting.PostingId).FirstOrDefault();
                                if (atsUrl != null)
                                {
                                    if (!string.IsNullOrEmpty(atsUrl.usePassthrough.ToString()))
                                    {
                                        if (atsUrl.usePassthrough.ToString() == "True")
                                        {
                                            emailCode = "CAREER_EDGE_POSTING_APPLICATION_ATS_LINK";
                                            atsURL = atsUrl.passthroughUrl;
                                        }
                                    }
                                }
                            }

                            AutoEmail _email = cmscxt.AutoEmail.FirstOrDefault(em => em.emailCode == emailCode);
                            CMSEmail cmsemail = new CMSEmail(_email.autoEmailId);

                            subject = cmsemail.content.en_subject;
                            emailContent = cmsemail.content.en_htmlContent;
                            from = cmsemail.content.en_from;

                            if (emailContent != null)
                            {
                                // Replace the tags with the correct values
                                emailContent = emailContent.Replace("[INTERN_NAME]", string.Format("{0} {1}", loggedInUser.firstname, loggedInUser.lastname));
                                emailContent = emailContent.Replace("[JOB_TITLE]", string.Format("{0}", selectedPosting.JobTitle));

                                emailContent = emailContent.Replace("[EMPLOYER]", string.Format("{0}", host.companyName));

                                if (atsURL != null)
                                {
                                    emailContent = emailContent.Replace("[ATS_LINK]", string.Format("{0}", atsURL));
                                }

                                Utility.SendEmail(from, loggedInUser.email, subject, emailContent, null);

                                if (host != null)
                                {
                                    // Add an Alert into the activity log for this Registrant
                                    var alert = new ActivityLog
                                                    {
                                                        detail = string.Format("You have applied for the {0} position at {1}. Please click <a href='../applications/applicationDetail.aspx?id={2}'>here</a> to view your application. ", selectedPosting.JobTitle, host.companyName, applicationId),
                                                        userId = loggedInUser.userId,
                                                        type = (int) ActivityLogCategoryEnum.Alert,
                                                        dateCreated = DateTime.Now,
                                                        autoGenerated = true,
                                                        enabled = true
                                                    };

                                    cxt.ActivityLog.AddObject(alert);

                                    cxt.SaveChanges();
                                }
                            }

                            // Now send an email to the host user that created the posting
                            if (selectedPosting.ApplicationEmail)
                            {
                                _email = cmscxt.AutoEmail.FirstOrDefault(em => em.emailCode == "CAREER_EDGE_POSTING_APPLICATION_HOST");
                                cmsemail = new CMSEmail(_email.autoEmailId);

                                subject = cmsemail.content.en_subject;
                                emailContent = cmsemail.content.en_htmlContent;
                                from = cmsemail.content.en_from;
                              
                                if (emailContent != null)
                                {
                                    HostUsers creator = cxt.HostUsers.FirstOrDefault(h => h.hostUserId == selectedPosting.ContactId && selectedPosting.HostCreated);
                                    CEOModel.user_details hostuser = cxt.user_details.FirstOrDefault(h => h.userId == creator.userId);
                                    if (creator != null)
                                    {
                                        // Replace the tags with the correct values
                                        emailContent = emailContent.Replace("[HOSTUSER_NAME]", string.Format("{0} {1}", hostuser.firstname, hostuser.lastname));
                                        emailContent = emailContent.Replace("[INTERN_NAME]", string.Format("{0} {1}", loggedInUser.firstname, loggedInUser.lastname));
                                        emailContent = emailContent.Replace("[JOB_TITLE]", string.Format("{0}", selectedPosting.JobTitle));

                                        Utility.SendEmail(from, hostuser.email, subject, emailContent, null);

                                        // Add an Alert into the activity log for this host user
                                        var alert = new ActivityLog
                                                        {
                                                            detail = string.Format("{0} {1} has just applied for the {2}. Please click <a href='../internship-postings/applicationDetail.aspx?id={3}'>here</a> to view the application. ", loggedInUser.firstname, loggedInUser.lastname, selectedPosting.JobTitle, applicationId),
                                                            hostUserId = creator.hostUserId,
                                                            type = (int) ActivityLogCategoryEnum.Alert,
                                                            dateCreated = DateTime.Now,
                                                            autoGenerated = true,
                                                            enabled = true
                                                        };

                                        cxt.ActivityLog.AddObject(alert);

                                        cxt.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
