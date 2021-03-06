import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoggedInComponent } from './pages/logged-in/logged-in.component';
import { HomeComponent } from './pages/logged-in/home/home.component';
import { ProfileComponent } from './pages/logged-in/profile/profile.component';
import { ThreadComponent } from './pages/logged-in/thread/thread.component';
import { SettingsComponent } from './pages/logged-in/profile/settings/settings.component';
import { DetailsComponent } from './pages/logged-in/profile/details/details.component';
import { OverviewComponent } from './pages/logged-in/profile/overview/overview.component';
import { FriendsComponent } from './pages/logged-in/profile/friends/friends.component';
import { GroupComponent } from './pages/logged-in/group/group.component';
import { GroupsComponent } from './pages/logged-in/groups/groups.component';
import { FriendRequestsComponent } from './pages/logged-in/profile/friend-requests/friend-requests.component';
import { UserGroupRequestsComponent } from './pages/logged-in/profile/user-group-requests/user-group-requests.component';
import { GroupRequestsComponent } from './components/group/invitations/group-requests/group-requests.component';
import { GroupInviteComponent } from './components/group/invitations/group-invite/group-invite.component';

import { LoggedOutComponent } from './pages/logged-out/logged-out.component';
import { RegisterComponent } from './pages/logged-out/register/register.component';
import { LoginComponent } from './pages/logged-out/login/login.component';
import { ResetComponent } from './pages/logged-out/reset/reset.component';
import { ForgotComponent } from './pages/logged-out/forgot/forgot.component';

import { NotFoundComponent } from './components/shared/not-found/not-found.component';

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
        path: 'groups',
        component: GroupsComponent,
      },
      {
        path: 'group/:id',
        component: GroupComponent,
        children: [
          {
            path: '',
            component: GroupInviteComponent,
          },
          {
            path: 'requests',
            component: GroupRequestsComponent,
          },
        ],
      },
      {
        path: 'thread/:id',
        component: ThreadComponent,
      },
      {
        path: 'profile/:id',
        component: ProfileComponent,
        children: [
          {
            path: '',
            component: OverviewComponent,
          },
          {
            path: 'friends',
            component: FriendsComponent,
          },
          {
            path: 'grouprequests',
            component: UserGroupRequestsComponent,
          },
          {
            path: 'friendrequests',
            component: FriendRequestsComponent,
          },
          {
            path: 'details',
            component: DetailsComponent,
          },
          {
            path: 'settings',
            component: SettingsComponent,
          },
        ],
      },
    ],
  },
  {
    //doesnt work
    path: 'admin',
    component: NotFoundComponent,
    canActivate: [RoleGuardService],
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
