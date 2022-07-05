import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';

import { ErrorService } from './services/error/error.service';
import { AlertifyService } from './services/alertify/alertify.service';

import { AppComponent } from './app.component';
import { LoginComponent } from './pages/logged-out/login/login.component';
import { RegisterComponent } from './pages/logged-out/register/register.component';
import { HeaderComponent } from './layout/header/header.component';
import { NavComponent } from './layout/nav/nav.component';
import { FooterComponent } from './layout/footer/footer.component';
import { LoggedInComponent } from './pages/logged-in/logged-in.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { ProfileComponent } from './pages/logged-in/profile/profile.component';
import { HomeComponent } from './pages/logged-in/home/home.component';
import { LoggedOutComponent } from './pages/logged-out/logged-out.component';
import { ForgotComponent } from './pages/logged-out/forgot/forgot.component';
import { ResetComponent } from './pages/logged-out/reset/reset.component';
import { PostsComponent } from './components/home/timeline/posts.component';
import { PostComponent } from './components/shared/post/post.component';
import { SearchComponent } from './components/home/search/search.component';
import { CreatePostComponent } from './components/shared/create-post/create-post.component';
import { ProfilepreviewComponent } from './components/home/profilepreview/profilepreview.component';
import { SettingsComponent } from './pages/logged-in/profile/settings/settings.component';
import { DetailsComponent } from './pages/logged-in/profile/details/details.component';
import { OverviewComponent } from './pages/logged-in/profile/overview/overview.component';
import { FriendsComponent } from './pages/logged-in/profile/friends/friends.component';
import { ThreadComponent } from './pages/logged-in/thread/thread.component';
import { RequestsComponent } from './pages/logged-in/profile/requests/requests.component';
import { CommentsComponent } from './components/thread/comments/comments.component';
import { CommentComponent } from './components/thread/comment/comment.component';
import { MainPostComponent } from './components/thread/main-post/main-post.component';
import { CreateCommentComponent } from './components/thread/create-comment/create-comment.component';
import { RecommendedComponent } from './components/home/recommended/recommended.component';
import { GroupsComponent } from './pages/logged-in/groups/groups.component';
import { GroupComponent } from './pages/logged-in/group/group.component';
import { SearchgroupsComponent } from './components/groups/searchgroups/searchgroups.component';
import { CreateGroupComponent } from './components/groups/create-group/create-group.component';
import { UpdateProfileComponent } from './components/profile/update-profile/update-profile.component';
import { ChangePasswordComponent } from './components/profile/change-password/change-password.component';
import { ChangeEmailComponent } from './components/profile/change-email/change-email.component';
import { DeleteUserComponent } from './components/profile/delete-user/delete-user.component';
import { FriendRequestsComponent } from './pages/logged-in/profile/friend-requests/friend-requests.component';
import { FriendRequestsSentComponent } from './components/profile/friend-requests-sent/friend-requests-sent.component';
import { FriendRequestsPendingComponent } from './components/profile/friend-requests-pending/friend-requests-pending.component';
import { GroupRequestsPendingComponent } from './components/group/group-requests-pending/group-requests-pending.component';
import { GroupRequestsSentComponent } from './components/group/group-requests-sent/group-requests-sent.component';
import { GroupRequestPendingComponent } from './components/group/group-request-pending/group-request-pending.component';
import { GroupRequestSentComponent } from './components/group/group-request-sent/group-request-sent.component';
import { FriendRequestPendingComponent } from './components/profile/friend-request-pending/friend-request-pending.component';
import { FriendRequestSentComponent } from './components/profile/friend-request-sent/friend-request-sent.component';
import { GroupInfoComponent } from './components/group/group-info/group-info.component';
import { GroupPostsComponent } from './components/group/group-posts/group-posts.component';
import { GroupUsersComponent } from './components/group/group-users/group-users.component';
import { SearchGroupUsersComponent } from './components/group/search-group-users/search-group-users.component';
import { GroupInviteComponent } from './components/group/group-invite/group-invite.component';
import { UserGroupRequestsComponent } from './pages/logged-in/profile/user-group-requests/user-group-requests.component';
import { UserGroupRequestPendingComponent } from './components/profile/user-group-request-pending/user-group-request-pending.component';
import { UserGroupRequestSentComponent } from './components/profile/user-group-request-sent/user-group-request-sent.component';
import { UserGroupRequestsPendingComponent } from './components/profile/user-group-requests-pending/user-group-requests-pending.component';
import { UserGroupRequestsSentComponent } from './components/profile/user-group-requests-sent/user-group-requests-sent.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    NavComponent,
    FooterComponent,
    LoggedInComponent,
    NotFoundComponent,
    LoadingComponent,
    ProfileComponent,
    HomeComponent,
    LoggedOutComponent,
    ForgotComponent,
    ResetComponent,
    PostsComponent,
    PostComponent,
    SearchComponent,
    CreatePostComponent,
    ProfilepreviewComponent,
    SettingsComponent,
    DetailsComponent,
    ThreadComponent,
    OverviewComponent,
    FriendsComponent,
    RequestsComponent,
    CommentsComponent,
    CommentComponent,
    MainPostComponent,
    CreateCommentComponent,
    RecommendedComponent,
    GroupsComponent,
    GroupComponent,
    SearchgroupsComponent,
    CreateGroupComponent,
    UpdateProfileComponent,
    ChangePasswordComponent,
    ChangeEmailComponent,
    DeleteUserComponent,
    FriendRequestsComponent,
    FriendRequestsSentComponent,
    FriendRequestsPendingComponent,
    GroupRequestsPendingComponent,
    GroupRequestsSentComponent,
    GroupRequestPendingComponent,
    GroupRequestSentComponent,
    FriendRequestPendingComponent,
    FriendRequestSentComponent,
    GroupInfoComponent,
    GroupPostsComponent,
    GroupUsersComponent,
    SearchGroupUsersComponent,
    GroupInviteComponent,
    UserGroupRequestsComponent,
    UserGroupRequestsSentComponent,
    UserGroupRequestsPendingComponent,
    UserGroupRequestSentComponent,
    UserGroupRequestPendingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatPaginatorModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorService, multi: true },
    AlertifyService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
