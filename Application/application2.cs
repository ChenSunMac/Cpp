<%@ page title="" language="C#" masterpagefile="~/registrants/MasterPage.master" autoeventwireup="true" validaterequest="false" codefile="postingApplication.aspx.cs" inherits="registrants_internship_postings_postingApplication" %>

<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        h3 {
            font-weight: bold;
            margin-bottom: 6px;
            margin-top: 20px;
        }
    </style>

    <link href="/css/jquery.cleditor.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="/ckeditor/adapters/jquery.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="leftColumnContent" runat="Server">
    <%--display the inputs to allow a registrant to apply for a intern position
    this will allow the registrant to apply using either an uploaded resume
    or to build thier own resume via the resume builder--%>

    <asp:Panel ID="FormPanel" runat="server" Visible="true">
        <ceo:message runat="server" id="MessageControl" messagetype="Success" visible="false" />

        <div style="width: 700px; display: block;">
            <%-- display the Intern statements if any and the coverletter editor --%>
            <asp:Panel ID="pnlCoverLetter" runat="server" Width="650px">
                <br />
                <table>
                    <tr>
                        <td>
                            <div style="width: 220px; margin-left: 15px">
                                <asp:Image ID="imgLogo" runat="server"></asp:Image>
                            </div>
                        </td>
                        <td>
                            <div style="width: auto; margin-left: 10px; font-size: 1.4em; border-width: 1px; border-style: dashed; border-color: gray; padding: 3%;">
                                You have chosen to apply to the
                        <asp:Label runat="server" ID="lblJobTitle" Style="color: #C40D40; font-weight: bolder;"></asp:Label>
                                (Posting ID:
                        <asp:Label runat="server" ID="lblPostingId" Style="color: #C40D40; font-weight: bolder"></asp:Label>) paid internship offered at
                        <asp:Label runat="server" ID="lblOrganization" Style="color: #C40D40; font-weight: bolder"></asp:Label>
                                <div style="font-size: 12px; line-height: 12px; border-top-style: solid; border-top-color: grey; border-top-width: 1px; padding-top: 1%;">
                                    If this is incorrect please close all other postings you may have open in tabs, go back to the posting you are interested in and click apply to reload the application page.
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--the intern agreement statements are only visible if the host has elected to use any of the statements provided by CareerEdge--%>
            <asp:Panel runat="server" ID="pnlStatements" ClientIDMode="Static" Visible="false">
                <h2>Internship Application Agreements</h2>
                <p><strong>*Please read the following statements and indicate your agreement by checking the checkbox provided.*</strong></p>
                <asp:Panel runat="server" ID="pnlStatement1" Visible="False">
                    <asp:CheckBox runat="server" ID="cbxStatement1" ClientIDMode="Static" /><span style="line-height: 20px"><asp:Label runat="server" ID="lblStatement1"></asp:Label></span><br />
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlStatement2" Visible="False">
                    <asp:CheckBox runat="server" ID="cbxStatement2" ClientIDMode="Static" /><span style="line-height: 20px"><asp:Label runat="server" ID="lblStatement2"></asp:Label></span><br />
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlStatement3" Visible="False">
                    <asp:CheckBox runat="server" ID="cbxStatement3" ClientIDMode="Static" /><span style="line-height: 20px"><asp:Label runat="server" ID="lblStatement3"></asp:Label></span><br />
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlStatement4" Visible="False">
                    <asp:CheckBox runat="server" ID="cbxStatement4" ClientIDMode="Static" /><span style="line-height: 20px"><asp:Label runat="server" ID="lblStatement4"></asp:Label></span><br />
                </asp:Panel>
            </asp:Panel>


            <h2>Cover Letter</h2>
            <br />
            <asp:Panel runat="server" ID="CoverPanel" ClientIDMode="Static">
                <asp:Literal ID="Literal2" runat="server" Text="Select an option below for submitting your cover letter"></asp:Literal><br />
                <br />
                <asp:RadioButtonList ID="coverType" runat="server" RepeatDirection="Vertical" RepeatColumns="1" CssClass="radioButtonList" ClientIDMode="Static">
                    <asp:ListItem Value="UR" Text="Upload Cover Letter"></asp:ListItem>
                    <asp:ListItem Value="RB" Text="Cover Letter Builder"></asp:ListItem>
                </asp:RadioButtonList>

                <asp:Panel runat="server" ID="PanelUploadC" ClientIDMode="Static" Style="display: none;">
                    <br />
                    <h2>Upload Cover Letter</h2>
                    <br />
                    <table style="width: 650px;">
                        <tr>
                            <td class="formTitleLonger">Choose the file you would like to upload, accepted document types are listed below:</td>
                        </tr>
                        <tr>
                            <td class="formFields" style="padding-left: 15px;">
                                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:CareerEdgeResource, UploadedDocumentTypes %>"></asp:Literal><br />
                                <asp:FileUpload ID="fileCover" ClientIDMode="Static" runat="server" />
                                <asp:CustomValidator
                                    ID="CustomValidator1"
                                    ControlToValidate="fileCover"
                                    OnServerValidate="ValidateCoverUpload"
                                    ErrorMessage="You have chosen an invalid file type, please upload your cover letter in one of the approved document formats."
                                    ValidationGroup="UploadGroupC"
                                    CssClass="error"
                                    Display="Dynamic"
                                    EnableClientScript="false"
                                    ValidateEmptyText="True"
                                    runat="server"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>

                <asp:Panel runat="server" ID="PanelBuilderC" ClientIDMode="Static" Style="display: none;">
                    <br />
                    <h2>Cover Letter Builder</h2>
                    <asp:RequiredFieldValidator ID="coverLetterRequiredFieldValidator" runat="server" ClientIDMode="Static"
                        ErrorMessage="Required"
                        ControlToValidate="txtCoverLetter"
                        Display="Dynamic"
                        CssClass="error"
                        EnableClientScript="false"
                        ValidationGroup="ResumeGroupC"> </asp:RequiredFieldValidator>
                    <ckeditor:ckeditorcontrol id="txtCoverLetter" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>
                </asp:Panel>
            </asp:Panel>
            <br />
            <%-- display the resume options to the registrant The registrant has the following options for submitting a resume 
                - Resume Builder
                - Upload Resume document --%>

            <asp:Panel ID="ResumePanel" runat="server" ClientIDMode="Static" Width="650px">
                <h2>Resume</h2>
                <p><strong><%-- TODO: add new text? --%></strong></p>

                <%-- give the registrant the option to either upload a resume or to build a reume via resume builder --%>
                <asp:Panel runat="server" ID="pnlSelect" ClientIDMode="Static">
                    <asp:Literal ID="Literal1" runat="server" Text="Now select an option below for submitting your resume"></asp:Literal><br />
                    <br />
                    <asp:RadioButtonList ID="resumeType" runat="server" RepeatDirection="Vertical" RepeatColumns="1" CssClass="radioButtonList" ClientIDMode="Static">
                        <asp:ListItem Value="UR" Text="Upload Resume"></asp:ListItem>
                        <asp:ListItem Value="RB" Text="Resume Builder"></asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlUpload" ClientIDMode="Static" Style="display: none;">
                    <br />
                    <h2>Upload Resume</h2>
                    <br />
                    <ol style="color: #C40D40; font-weight: bolder;">
                        <li>Before submitting your application you will be able to preview it, including the resume/cover letter you upload.</li>
                        <li>Please allow time for processing of the application and do not submit more than once.</li>
                        <li>The upload process upon final submission of this application will take between 30-60s on average. Your patience is appreciated.</li>
                    </ol>
                    <br />
                    <table style="width: 650px;">
                        <%--<tr>
                            <td class="formTitleLonger">
                                <asp:CheckBox runat="server" ID="cbxUseUploaded" ClientIDMode="Static" Enabled="false" />
                                <span style="line-height: 20px">Check this option if you would like to apply with a previously uploaded resume. <strong>IF YOU ENCOUNTER AN ERROR ON SUBMIT, PLEASE LEAVE THIS UNCHECKED AND UPLOAD A NEW DOCUMENT.</strong></span><br />
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="formTitleLonger">Choose the file you would like to upload, accepted document types are listed below:</td>
                        </tr>
                        <tr>
                            <td class="formFields" style="padding-left: 15px;">
                                <asp:Literal ID="Literal91" runat="server" Text="<%$ Resources:CareerEdgeResource, UploadedDocumentTypes %>"></asp:Literal><br />
                                <asp:FileUpload ID="fileResume" ClientIDMode="Static" runat="server" />
                                <asp:CustomValidator
                                    ID="customResumeFileValidator"
                                    ControlToValidate="fileResume"
                                    OnServerValidate="ValidateResumeUpload"
                                    ErrorMessage="You have chosen an invalid file type, please upload your resume in one of the approved document formats."
                                    ValidationGroup="UploadGroup"
                                    CssClass="error"
                                    Display="Dynamic"
                                    EnableClientScript="false"
                                    ValidateEmptyText="True"
                                    runat="server"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlBuilder" ClientIDMode="Static" Style="display: none;">
                    <br />
                    <h2>Resume Builder</h2>
                    <br />
                    <table style="width: 650px;">
                        <tr>
                            <td class="formTitleLonger">Would you like to use a previously submitted application as a starting point?</td>
                        </tr>
                        <tr>
                            <td class="formFields">
                                <asp:DropDownList ID="ddlPostings" runat="server" CssClass="shorterFormInputField" ClientIDMode="Static">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="formFields" style="padding-left: 15px;">
                                <asp:Button ID="btnUpdate" runat="server" Text="Load Resume" CssClass="submitFormButtonWider" ClientIDMode="Static" OnClick="UpdateResume" />
                            </td>
                        </tr>
                    </table>

                    <h3 class="cleditorTitle">Contact Information<span class="info" title="Your contact info can be updated by clicking on your profile page"></span>  :</h3>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label><br />
                    <asp:Label ID="lblHomePhone" runat="server"></asp:Label><br />
                    <asp:Label ID="lblCellPhone" runat="server"></asp:Label>
                    <asp:Label ID="lblAddress1" runat="server"></asp:Label><br />
                    <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                    <asp:Label ID="lblCity" runat="server"></asp:Label><br />
                    <asp:Label ID="lblProvince" runat="server"></asp:Label><br />
                    <asp:Label ID="lblPostcode" runat="server"></asp:Label>

                    <h3 class="cleditorTitle">Career Objective:<span class="errorText">*</span></h3>
                    <asp:RequiredFieldValidator ID="careerObjectiveRequiredFieldValidator" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="careerObjective"
                        Display="Dynamic"
                        CssClass="error"
                        EnableClientScript="false"
                        ValidationGroup="ResumeGroup">
                    </asp:RequiredFieldValidator>
                    <ckeditor:ckeditorcontrol id="careerObjective" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Skills:<span class="errorText">*</span></h3>
                    <asp:RequiredFieldValidator ID="skillsRequiredFieldValidator" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="skills"
                        Display="Dynamic"
                        CssClass="error"
                        EnableClientScript="false"
                        ValidationGroup="ResumeGroup">
                    </asp:RequiredFieldValidator>
                    <ckeditor:ckeditorcontrol id="skills" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Education:<span class="errorText">*</span></h3>
                    <asp:RequiredFieldValidator ID="educationRequiredFieldValidator" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="education"
                        Display="Dynamic"
                        CssClass="error"
                        EnableClientScript="false"
                        ValidationGroup="ResumeGroup">
                    </asp:RequiredFieldValidator>
                    <ckeditor:ckeditorcontrol id="education" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Related Experience:<span class="errorText">*</span></h3>
                    <asp:RequiredFieldValidator ID="workExperienceRequiredFieldValidator" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="workExperience"
                        Display="Dynamic"
                        CssClass="error"
                        EnableClientScript="false"
                        ValidationGroup="ResumeGroup">
                    </asp:RequiredFieldValidator>
                    <ckeditor:ckeditorcontrol id="workExperience" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Professional Qualifications:</h3>
                    <ckeditor:ckeditorcontrol id="professionalQualifications" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Awards / Achievements:</h3>
                    <ckeditor:ckeditorcontrol id="awardsAchievements" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Affiliations:</h3>
                    <ckeditor:ckeditorcontrol id="affiliations" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Volunteer Work:</h3>
                    <ckeditor:ckeditorcontrol id="volunteerWork" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Interests:</h3>
                    <ckeditor:ckeditorcontrol id="interests" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>

                    <h3 class="cleditorTitle">Additional Information:</h3>
                    <ckeditor:ckeditorcontrol id="additionalInformation" runat="server" width="650" resizeenabled="false" forcepasteasplaintext="true" clientidmode="Static"></ckeditor:ckeditorcontrol>
                </asp:Panel>

                <%-- display the questions the host asks the registrant to complete --%>
                <asp:Panel ID="QuestionsPanel" runat="server" ClientIDMode="Static" Width="650px">
                    <h2>Employer Questions</h2>
                    <br />
                    <p style="color: #C40D40;">
                        <strong>Once you have filled out any questions, you must PREVIEW your application before you can complete and submit it for consideration.
                        </strong>
                    </p>
                    <asp:Panel ID="NoQuestionsPanel" runat="server" ClientIDMode="Static" Visible="true">
                        <p>There are no employer questions for this posting</p>
                    </asp:Panel>
                    <asp:Panel ID="Question1Panel" runat="server" ClientIDMode="Static" Visible="false">
                        <h3>
                            <asp:Label ID="lblQuestion1" runat="server"></asp:Label></h3>
                        <asp:TextBox ID="txtQuestion1" runat="server" TextMode="MultiLine" Width="650px" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="question1RequiredFieldValidator" runat="server" ClientIDMode="Static"
                            Text="Required"
                            ControlToValidate="txtQuestion1"
                            Display="Dynamic"
                            CssClass="error"
                            EnableClientScript="false"
                            ValidationGroup="PostingApplicationGroup">
                        </asp:RequiredFieldValidator>
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Panel ID="Question2Panel" runat="server" ClientIDMode="Static" Visible="false">
                        <h3>
                            <asp:Label ID="lblQuestion2" runat="server"></asp:Label></h3>
                        <asp:TextBox ID="txtQuestion2" runat="server" TextMode="MultiLine" Width="650px" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="question2RequiredFieldValidator" runat="server" ClientIDMode="Static"
                            Text="Required"
                            ControlToValidate="txtQuestion2"
                            Display="Dynamic"
                            CssClass="error"
                            EnableClientScript="false"
                            ValidationGroup="PostingApplicationGroup">
                        </asp:RequiredFieldValidator>
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Panel ID="Question3Panel" runat="server" ClientIDMode="Static" Visible="false">
                        <h3>
                            <asp:Label ID="lblQuestion3" runat="server"></asp:Label></h3>
                        <asp:TextBox ID="txtQuestion3" runat="server" TextMode="MultiLine" Width="650px" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="question3RequiredFieldValidator" runat="server" ClientIDMode="Static"
                            Text="Required"
                            ControlToValidate="txtQuestion3"
                            Display="Dynamic"
                            CssClass="error"
                            EnableClientScript="false"
                            ValidationGroup="PostingApplicationGroup">
                        </asp:RequiredFieldValidator>
                        <br />
                    </asp:Panel>
                    <br />
                </asp:Panel>
                <br />
                <br />
                <br />
                <p style="color: #C40D40;"><strong>By submitting this application you are affirming that – should you be selected as the successful candidate for this internship position – you agree to the non-negotiable internship stipend rates: $2,400/month for recent graduates, graduates with disabilities, and CAF reservists, OR $2,700/month for internationally qualified professionals - less standard legislated payroll tax deductions.</strong></p>
                <p style="color: #C40D40;"><strong>In some cases, stipend rates will vary depending on the employer’s provisos articulated during the hiring process; these stipend rates are also non-negotiable.</strong></p>
                <br />
                <br />
                <table class="pager_table">
                    <tr>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnCancel" runat="server" Text="Cancel Application" OnClick="CancelApplication" Style="padding-left: 0px; border: none;" OnClientClick="return confirm('Are you sure you want to cancel your application?. This will delete all the data you have entered for this application.');" Height="30px" ImageUrl="~/images/formbuttons/cancelbutton.png" Width="100px" />
                        </td>
                        <td>
                            <asp:ImageButton ID="btnPreview" runat="server" Text="Preview Application" OnClick="PreviewApplication" ClientIDMode="Static" Style="border: none; padding-left: 0px; float: right;" ImageUrl="~/images/formbuttons/previewbutton.png" Height="30" Width="100" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />

            </asp:Panel>
        </div>

    </asp:Panel>

    <%--display the contents of the registrants application 
        if the registrant has elected to use the resume builder then
        display the contents of the resume builder but if the 
        registrant chooses to upload thier resume provide a link to
        the resume to download--%>

    <asp:Panel ID="PreviewPanel" Visible="false" runat="server">
        <h3>Please review the following carefully, this is what the employer will be seeing when they review your application.
        If you wish to make edits prior to SUBMITTING please hit the back button below. You may find the following helpful in
        <a href="http://www.careeredge.ca/registrants/resources/">increasing the persuasiveness of your resume</a>
            <br />
        </h3>
        <p style="color: #C40D40;"><strong>Once you are satisfied with your application please hit the SUBMIT button ONLY ONCE below to complete your application. The submission processing may take up to several minutes, we thank you for your patience.</strong></p>

        <%--Display the users coverletter and thier tombstone information--%>
        <asp:Panel ID="pnlUploadCPreview" runat="server">
            <fieldset class="fieldSet2ColWidth">
                <legend>Cover Letter</legend>
                <br />
                You have selected to apply with an uploaded cover letter:
            <asp:HyperLink runat="server" ClientIDMode="Static" ID="lnkPreviewCover"></asp:HyperLink>
                <asp:HiddenField runat="server" ID="tempFileC" />
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="pnlBuilderCPreview" runat="server">
            <fieldset class="fieldSet2ColWidth">
                <legend>Cover Letter</legend>
                <p>
                    <asp:Label ID="lblCoverLetter" runat="server"></asp:Label>
                </p>
            </fieldset>
        </asp:Panel>
        <fieldset id="resume" class="fieldSet2ColWidth">
            <legend>Resume</legend>
            <div style="display: block; text-align: center;">
                <asp:Label ID="Email" runat="server"></asp:Label><br />
                <asp:Label ID="HomePhone" runat="server"></asp:Label><br />
                <asp:Label ID="CellPhone" runat="server"></asp:Label><br />
                <asp:Label ID="Address1" runat="server"></asp:Label><br />
                <asp:Label ID="Address2" runat="server"></asp:Label>
                <asp:Label ID="City" runat="server"></asp:Label><br />
                <asp:Label ID="Province" runat="server"></asp:Label><br />
                <asp:Label ID="Postcode" runat="server"></asp:Label>
            </div>

            <%--if the registrant selected to upload thier resume display a link to the resume
            otherwise display the contents of the resume builder--%>

            <asp:Panel ID="pnlUploadPreview" runat="server">
                <br />
                You have selected to apply with an uploaded resume:
                <asp:HyperLink runat="server" ClientIDMode="Static" ID="lnkPreviewResume"></asp:HyperLink>
                <asp:HiddenField runat="server" ID="tempFile" />
            </asp:Panel>


            <asp:Panel ID="pnlBuilderPreview" runat="server">
                <br />
                <table class="twoColWidthWide">
                    <tr>
                        <td class="formTitles tallFields">Career Objective:
                        </td>
                        <td class="formFieldsBlock">
                            <asp:Label ID="careerOBJ" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Skills:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="lblSkills" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Education:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="edu" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Related Experience:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="workExp" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Professional Qualifications:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="qualifications" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Awards / Achievements:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="awards" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Affiliations:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="affil" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Volunteer Work:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="volunteer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Interests:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="lblInterests" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTitles tallFields">Additional Information:
                        </td>
                        <td class="formFields">
                            <asp:Label ID="additional" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </fieldset>

        <fieldset id="questions" class="fieldSet2ColWidth">
            <legend>Questions, if you have not answered we strongly recommend that you go back and do so.</legend>
            <p>
                <b>
                    <asp:Label ID="Question1" runat="server"></asp:Label></b><br />
                <asp:Label ID="lblAnswer1" runat="server"></asp:Label>
            </p>
            <p>
                <b>
                    <asp:Label ID="Question2" runat="server"></asp:Label></b><br />
                <asp:Label ID="lblAnswer2" runat="server"></asp:Label>
            </p>
            <p>
                <b>
                    <asp:Label ID="Question3" runat="server"></asp:Label></b><br />
                <asp:Label ID="lblAnswer3" runat="server"></asp:Label>
            </p>
            <br />
        </fieldset>

        <br />
        <asp:Panel runat="server" ID="pnlPreviewStatements" ClientIDMode="Static">
            <fieldset id="Fieldset1" class="fieldSet2ColWidth">
                <legend>By submitting this application you confirm the following to the host employer:</legend>
                <p>
                    <b>
                        <asp:Label ID="lblStatement1Preview" runat="server"></asp:Label></b><br />
                    <asp:Label ID="lblStatementAnsewer1" runat="server"></asp:Label>
                </p>
                <p>
                    <b>
                        <asp:Label ID="lblStatement2Preview" runat="server"></asp:Label></b><br />
                    <asp:Label ID="lblStatementAnsewer2" runat="server"></asp:Label>
                </p>
                <p>
                    <b>
                        <asp:Label ID="lblStatement3Preview" runat="server"></asp:Label></b><br />
                    <asp:Label ID="lblStatementAnsewer3" runat="server"></asp:Label>
                </p>
                <p>
                    <b>
                        <asp:Label ID="lblStatement4Preview" runat="server"></asp:Label></b><br />
                    <asp:Label ID="lblStatementAnsewer4" runat="server"></asp:Label>
                </p>
                <br />
            </fieldset>
            <br />
        </asp:Panel>

        <p style="color: #C40D40;"><strong>By submitting this application you are affirming that – should you be selected as the successful candidate for this internship position – you agree to the non-negotiable internship stipend rates: $2,400/month for recent graduates, graduates with disabilities, and CAF reservists, OR $2,700/month for internationally qualified professionals - less standard legislated payroll tax deductions.</strong></p>
        <p style="color: #C40D40;"><strong>In some cases, stipend rates will vary depending on the employer’s provisos articulated during the hiring process; these stipend rates are also non-negotiable.</strong></p>
        <br />
        <table class="pager_table">
            <tr>
                <td>&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="btnBack" runat="server" Text="Back" OnClick="ReturnToApplication" Style="padding-left: 0px; border: none;" Height="30px" ImageUrl="~/images/formbuttons/backbutton.png" Width="100px" />
                </td>
                <td>
                    <asp:ImageButton ID="btnSubmit" runat="server" Text="Submit Application" OnClientClick="showPostingAlert();" OnClick="SubmitApplication" ClientIDMode="Static" Style="border: none; padding-left: 0px; float: right;" ImageUrl="~/images/formbuttons/submitbutton.png" Height="30" Width="100" />
                </td>
            </tr>
        </table>
        <br />
        <br />

    </asp:Panel>

    <style type="text/css">
        #PostingContainer {
            width: 100%;
            height: 100%;
            z-index: 1400;
            display: none;
            background-repeat: repeat;
            background-position: left top;
            background-attachment: fixed;
            background-image: url(/images/maskBG.png);
            position: fixed;
            top: 0;
            left: 0;
        }

        #PostingPanel {
            width: 300px;
            height: 200px;
            position: fixed;
            top: 40%;
            left: 40%;
            border: solid 1px #000000;
            z-index: 1500;
            background-color: #ffffff;
            font-size: 14px;
            text-align: center;
            padding: 3px 3px 3px 3px;
            color: #fff;
            margin: 0 auto;
        }
    </style>

    <div id="PostingContainer">
        <div id="PostingPanel">
            <br />
            <div style="height: 66px;">
                <div id="TimeoutCountDown" style="font-size: 20px;">
                    <img src="../../images/processingapplication.gif" />
                </div>
            </div>
            <br />
            <p style="color: #C40D40;"><strong>Please wait while your application is processing. The submission processing may take up to several minutes, we thank you for your patience.</strong></p>
        </div>
    </div>
    <script type="text/javascript">
        jQuery.fn.exists = function () { return this.length > 0; }

        //--
        //-- displays either the resume builder form or the uplaod form
        //--
        $('#resumeType').change(function () {
            if ($('#resumeType input:checked').val() == 'UR') {
                //-- show the upload panel
                $('#pnlUpload').show();
                $('#pnlBuilder').hide();
            } else {
                //-- show the resume builder panel
                $('#pnlUpload').hide();
                $('#pnlBuilder').show();
            }
        });

        $('#coverType').change(function () {
            if ($('#coverType input:checked').val() == 'UR') {
                //-- show the upload panel
                $('#PanelUploadC').show();
                $('#PanelBuilderC').hide();
            } else {
                //-- show the resume builder panel
                $('#PanelUploadC').hide();
                $('#PanelBuilderC').show();
            }
        });

        //--
        //-- prevents multiple button submision on the submit button
        //--
        $(document).ready(function () {
            $('form').submit(function () {
                if (typeof jQuery.data(this, "disabledOnSubmit") == 'undefined') {
                    jQuery.data(this, "disabledOnSubmit", { submited: true });
                    $('#btnSave', this).each(function () {
                        $(this).attr("disabled", "disabled");
                    });
                    $('#btnBack', this).each(function () {
                        $(this).attr("disabled", "disabled");
                    });
                    return true;
                }
                else {
                    return false;
                }
            });
        });

        function showPostingAlert() {
            $(this).addClass("loading");
            $('#PostingContainer').show();
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="rightColumnContent" runat="Server">
</asp:Content>


