using ASPNETMVCWebApp.ViewModels;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCWebApp.Controllers;


public class AccountController : Controller
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly AccountService _accountService;

    public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AccountService accountService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _accountService = accountService;
    }

    #region HttpGet signup
    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        return View();
    }
    #endregion


    #region HttpPost Signup
    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
            if (exists)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email address already exists");
                ViewData["ErrorMessage"] = "User with the same email address already exists";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                UserName = viewModel.Email
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Account");
            }
        }
        return View(viewModel);
    }
    #endregion


    #region HttpGetSignIn
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        return View();
    }
    #endregion


    #region PostSignIn
    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }
        }
        ModelState.AddModelError("IncorrectValues", "Incorrect email or password");
        ViewData["ErrorMessage"] = "Incorrect email or password";
        return View(viewModel);
    }
    #endregion

    #region Signout
    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }
    #endregion


    #region DetailsGet
    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Account");

        var viewModel = new AccountDetailsViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };

        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }
    #endregion

    #region DetailsPost
    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Account");

        if (ModelState.IsValid)
        {
            if (viewModel.BasicInfo != null)
            {
                
            }
            if (viewModel.AddressInfo != null) { }
        }

        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();

        return View(viewModel);
    }
    #endregion

    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!
        };
    }


    private async Task<BasicInfoViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new BasicInfoViewModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Bio = user.Bio
        };
    }

    private async Task<AddressInfoViewModel> PopulateAddressInfoAsync()
    {

        return new AddressInfoViewModel();
    }
}

//        var result = await _userManager.UpdateAsync(viewModel.User);
//        if (!result.Succeeded)
//        {
//            ModelState.AddModelError("Failed To Save Data", "Unable to save the data");
//            ViewData["ErrorMessage"] = "Unable to save the data";
//        }
//        return RedirectToAction("Details", "Account", viewModel);


//[HttpPost]
//public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
//{
//    var result = await _accountService.UpdateUserAccountAsync(viewModel.User);
//    if (!result.Succeeded)
//    {
//        ModelState.AddModelError("Failed To Save Data", "Unable to save the data");
//        ViewData["ErrorMessage"] = "Unable to save the data";
//    }
//    return RedirectToAction("Details", "Account", new { id = viewModel.User.Id});
//}
//#region SaveBasicInfo
//[HttpPost]
//public IActionResult SaveBasicInfo(AccountDetailsViewModel viewModel)
//{
//    if (TryValidateModel(viewModel.BasicInfo))
//    {
//        return RedirectToAction("Home", "Default");
//    }

//    return View("Details", viewModel);
//}
//#endregion

//#region SaveAddressInfo
//[HttpPost]
//public IActionResult SaveAddressInfo(AccountDetailsViewModel viewModel)
//{
//    if (TryValidateModel(viewModel.AddressInfo))
//    {
//        return RedirectToAction("Home", "Default");
//    }

//    return View("Details", viewModel);
//}
//#endregion