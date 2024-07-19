﻿using Acme.QLDN.Localization;
using Acme.QLDN.MultiTenancy;
using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.QLDN.Web.Menus;

public class QLDNMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<QLDNResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                QLDNMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "QLDN",
        l["Menu:OrgUnits"],
        icon: "fa fa-book",
        url: "/OrgUnits"
    )
);

        return Task.CompletedTask;
    }
}
