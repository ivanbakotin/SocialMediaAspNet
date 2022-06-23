import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoggedInComponent } from './pages/logged-in/logged-in.component';
import { FriendsComponent } from './pages/logged-in/friends/friends.component';
import { HomeComponent } from './pages/logged-in/home/home.component';
import { ProfileComponent } from './pages/logged-in/profile/profile.component';
import { AdminComponent } from './pages/logged-in/admin/admin.component';

import { LoggedOutComponent } from './pages/logged-out/logged-out.component';
import { RegisterComponent } from './pages/logged-out/register/register.component';
import { LoginComponent } from './pages/logged-out/login/login.component';
import { ResetComponent } from './pages/logged-out/reset/reset.component';
import { ForgotComponent } from './pages/logged-out/forgot/forgot.component';

import { NotFoundComponent } from './components/not-found/not-found.component';

import { AuthGuardService } from './services/auth/authGuard.service';
import { RoleGuardService } from './services/auth/roleGuard.service';

const routes: Routes = [
  {
    path: 'auth',
    component: LoggedOutComponent,
    children: [
      {
        path: '',
        component: LoginComponent,
      },
      {
        path: 'register',
        component: RegisterComponent,
      },
      {
        path: 'forgot',
        component: ForgotComponent,
      },
      {
        path: 'reset/:id',
        component: ResetComponent,
      },
    ],
  },
  {
    path: '',
    component: LoggedInComponent,
    canActivate: [AuthGuardService],
    children: [
      {
        path: 'home',
        component: HomeComponent,
      },
      {
        path: 'friends',
        component: FriendsComponent,
      },
      {
        path: 'post/:id',
        component: FriendsComponent,
      },
      {
        path: 'profile/:id',
        component: ProfileComponent,
      },
    ],
  },
  {
    //doesnt work
    path: 'admin',
    component: AdminComponent,
    canActivate: [RoleGuardService],
  },
  {
    //doesnt work
    path: '*',
    component: NotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
