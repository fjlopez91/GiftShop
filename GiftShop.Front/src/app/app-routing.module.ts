import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DefaultLayoutComponent } from "./containers/default-layout/default-layout.component";

const routes: Routes = [
    {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full'
    },
    {
        path: '',
        component: DefaultLayoutComponent,
        data: {
            title: 'Home'
        },
        children: [
            {
                path: 'products',
                loadChildren: () =>
                    import('./products/products.module').then((m) => m.ProductsModule)
            }
        ]
    },
    {path: '**', redirectTo: 'products'}
];

@NgModule({
    imports: [
      RouterModule.forRoot(routes, {
        scrollPositionRestoration: 'top',
        anchorScrolling: 'enabled',
        initialNavigation: 'enabledBlocking'
        // relativeLinkResolution: 'legacy'
      })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}