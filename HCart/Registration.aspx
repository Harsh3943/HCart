<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="HCart.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>HCart | Registration Page (v2)</title>

<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback">

<link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">

<link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">

<link rel="stylesheet" href="../../dist/css/adminlte.min.css?v=3.2.0">
<script defer="" referrerpolicy="origin" src="/cdn-cgi/zaraz/s.js?z=JTdCJTIyZXhlY3V0ZWQlMjIlM0ElNUIlNUQlMkMlMjJ0JTIyJTNBJTIyQWRtaW5MVEUlMjAzJTIwJTdDJTIwUmVnaXN0cmF0aW9uJTIwUGFnZSUyMCh2MiklMjIlMkMlMjJ4JTIyJTNBMC45NzUxNDA0NTI0Mzc0MDA2JTJDJTIydyUyMiUzQTE1MzYlMkMlMjJoJTIyJTNBODY0JTJDJTIyaiUyMiUzQTcwNyUyQyUyMmUlMjIlM0ExNTM2JTJDJTIybCUyMiUzQSUyMmh0dHBzJTNBJTJGJTJGYWRtaW5sdGUuaW8lMkZ0aGVtZXMlMkZ2MyUyRnBhZ2VzJTJGZXhhbXBsZXMlMkZyZWdpc3Rlci12Mi5odG1sJTIyJTJDJTIyciUyMiUzQSUyMmh0dHBzJTNBJTJGJTJGYWRtaW5sdGUuaW8lMkZ0aGVtZXMlMkZ2MyUyRiUyMiUyQyUyMmslMjIlM0EyNCUyQyUyMm4lMjIlM0ElMjJVVEYtOCUyMiUyQyUyMm8lMjIlM0EtMzMwJTJDJTIycSUyMiUzQSU1QiU1RCU3RA=="></script><script nonce="08ccf462-eb8d-4a07-8c08-9b31d926f004">(function(w,d){!function(a,b,c,d){a[c]=a[c]||{};a[c].executed=[];a.zaraz={deferred:[],listeners:[]};a.zaraz.q=[];a.zaraz._f=function(e){return async function(){var f=Array.prototype.slice.call(arguments);a.zaraz.q.push({m:e,a:f})}};for(const g of["track","set","debug"])a.zaraz[g]=a.zaraz._f(g);a.zaraz.init=()=>{var h=b.getElementsByTagName(d)[0],i=b.createElement(d),j=b.getElementsByTagName("title")[0];j&&(a[c].t=b.getElementsByTagName("title")[0].text);a[c].x=Math.random();a[c].w=a.screen.width;a[c].h=a.screen.height;a[c].j=a.innerHeight;a[c].e=a.innerWidth;a[c].l=a.location.href;a[c].r=b.referrer;a[c].k=a.screen.colorDepth;a[c].n=b.characterSet;a[c].o=(new Date).getTimezoneOffset();if(a.dataLayer)for(const n of Object.entries(Object.entries(dataLayer).reduce(((o,p)=>({...o[1],...p[1]})),{})))zaraz.set(n[0],n[1],{scope:"page"});a[c].q=[];for(;a.zaraz.q.length;){const q=a.zaraz.q.shift();a[c].q.push(q)}i.defer=!0;for(const r of[localStorage,sessionStorage])Object.keys(r||{}).filter((t=>t.startsWith("_zaraz_"))).forEach((s=>{try{a[c]["z_"+s.slice(7)]=JSON.parse(r.getItem(s))}catch{a[c]["z_"+s.slice(7)]=r.getItem(s)}}));i.referrerPolicy="origin";i.src="/cdn-cgi/zaraz/s.js?z="+btoa(encodeURIComponent(JSON.stringify(a[c])));h.parentNode.insertBefore(i,h)};["complete","interactive"].includes(b.readyState)?zaraz.init():a.addEventListener("DOMContentLoaded",zaraz.init)}(w,d,"zarazData","script");})(window,document);</script></head>
    <style>
    /* Center the container vertically and horizontally */
    body, html {
        height: 100%;
        margin: 0;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }

    /* Style for the container */
    .container {
        max-width: 400px; /* Adjust the maximum width as needed */
        width: 100%;
    }
</style>
<body>
    <div class="container">
    <div class="register-box" style="margin: 0 auto; width: 400px;">
<div class="card card-outline card-primary">
<div class="card-header text-center">
<a href="../../index2.html" class="h1"><b>H</b>Cart</a>
</div>
<div class="card-body">
<p class="login-box-msg">Register a new membership</p>
<form action="Registration.aspx" method="post" runat="server">

<div class="input-group mb-3">
    <asp:TextBox ID="txtfullname" class="form-control" placeholder="Full name" fdprocessedid="dkth8f" runat="server"></asp:TextBox><div class="input-group-append">
<div class="input-group-text">
<span class="fas fa-user"></span>
</div>
</div>
</div>
<div class="input-group mb-3">
    <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" fdprocessedid="l7lrmt" runat="server"></asp:TextBox>
    <div class="input-group-append">
<div class="input-group-text">
<span class="fas fa-envelope"></span>
</div>
</div>
</div>
<div class="input-group mb-3">
<input type="password" class="form-control" placeholder="Password" fdprocessedid="7pxp7d">
<div class="input-group-append">
<div class="input-group-text">
<span class="fas fa-lock"></span>
</div>
</div>
</div>
<div class="input-group mb-3">
    <asp:TextBox ID="txtRPassword" class="form-control" placeholder="Retype password" fdprocessedid="lc60oo" runat="server"></asp:TextBox>
    <div class="input-group-append">
<div class="input-group-text">
<span class="fas fa-lock"></span>
</div>
</div>
</div>
<div class="row">
<div class="col-8">
<div class="icheck-primary">
<input type="checkbox" id="agreeTerms" name="terms" value="agree">
<label for="agreeTerms">
I agree to the <a href="#">terms</a>
</label>
</div>
</div>

<div class="col-4">
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" class="btn btn-primary btn-block" fdprocessedid="z1cooh" runat="server" Text="Ragister" />
</div>

</div>
</form>
<div class="social-auth-links text-center">
<a href="#" class="btn btn-block btn-primary">
<i class="fab fa-facebook mr-2"></i>
Sign up using Facebook
</a>
<a href="#" class="btn btn-block btn-danger">
<i class="fab fa-google-plus mr-2"></i>
Sign up using Google+
</a>
</div>
<a href="LoginMaster.aspx" class="text-center">I already have a membership</a>
</div>

</div>
</div>
</body>
</html>
