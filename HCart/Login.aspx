<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HCart.Login" %>

<html>

<head>
    <style>
        table,
        th,
        td {
            border: 1px solid black;
            /* border-spacing: 50px;*/
            border-collapse: collapse;
        }

        table.center {
            margin-left: auto;
            margin-right: auto;
            margin-top: 100px;
        }

        #grad1 {
            background-image: linear-gradient(to left, white, skyblue);
        }
    </style>
</head>

<body id="grad1">
    <form runat="server">
    <table style="width: 60%;" class="center">
        <tr>
            <td
                style="width: 50%; background-image: url('Photos/Login page photo.jpg'); background-size: cover; background-repeat: no-repeat;">
                <p style="font-size: 28px; padding-left: 25px; color: aliceblue; text-align: left;">
                    <b>Welcome Page</b>
                </p>
                <p style="color: aliceblue; text-align: left; padding-left: 75px;">Sign In To
                    <br>
                    Continue</p>
            </td>
            <td
                style="padding-left: 40px; padding-top: 30px; padding-bottom: 50px; width: 40%; background-color: white;">
                <p style="color: saddlebrown; font-size: 25px;"><b> Sign In </b></p>
                <form action="Shoping Web Page Design/Shoping Web Page.html"></form>
                    <label for="Uname" style="color:palevioletred;"> Username </label><br><br>
                    <asp:TextBox ID="txtusername" runat="server" placeholder="Enter Your Email Or Phone"
                        style="border-top: 0px;border-left: 0px;border-right: 0px; border-color:brown; width: 300px;"></asp:TextBox><br><br>                <label for="Pname" style="color:palevioletred;"> Password </label><br><br>
                    <asp:TextBox ID="txtPaaword" runat="server"  placeholder="Enter Your Password"
                        style="border-top: 0px;border-left: 0px;border-right: 0px; border-color:brown; width: 300px;"></asp:TextBox> <br><br>
                        <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label><br><br>
                    <input type="checkbox" id="Remember" name="Remember" value="me">
                    <label for="Remember" style="color: saddlebrown;">Remember Me</label><br><br>
                    <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" runat="server" Text="Submit" 
                        style="width: 100px; text-align: center; padding: 3px;background-color: palevioletred;" href="General HTML Practice/Iframe Practice.html" /><br><br>
                <asp:Button ID="btnreg" runat="server" Text="Regstration"  style="width: 100px; text-align: center; padding: 3px;background-color: palevioletred;" href="General HTML Practice/Iframe Practice.html" /><br><br>
                    <p style="color: saddlebrown;">or Connect With Social Media</p><br>
                    <input type="submit" value="Sign In With Twiter" 
                        style="width: 300px;padding: 5px; background-color: palevioletred;"><br><br>
                    <input type="submit" value="Sign In With Facebook"
                        style="width: 300px;padding: 5px; background-color: palevioletred;">
                    
            

                
            </td>
        </tr>
    </table>
        </form>
</body>

</html>

