import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.scss'],
})
export class GroupComponent implements OnInit {
  constructor(private route: ActivatedRoute) {}

  groupID!: number;

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.groupID = routeParams['id'];
    });
  }
}
