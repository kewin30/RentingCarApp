import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./_guards/auth.guard";
import { NgModule } from "@angular/core";
import { NotFoundComponent } from "./errors/not-found/not-found.component";
import { ServerErrorComponent } from "./errors/server-error/server-error.component";
import { HomeComponent } from "./home/home.component";
import { AdminPanelComponent } from "./admin/admin-panel/admin-panel.component";
import { AdminGuard } from "./_guards/admin.guard";
import { CarsComponent } from "./cars/cars.component";




const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: '', 
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        {path: 'cars', component: CarsComponent},
        {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},
      ]
    },
    {path: 'not-found', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorComponent},
    {path: '**', component: NotFoundComponent, pathMatch: 'full'},
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }