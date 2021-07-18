import { Component, OnInit, Input } from '@angular/core';
import { Schedule } from '../../interfaces/schedule';
import { ScheduleService } from '../../services/schedule.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-schedule',
    templateUrl: './schedule.component.html',
    styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

    //@Input() theaterId!: number;
    //@Input() movieId!: string;
    theaterId: number = parseInt(this.route.snapshot.paramMap.get('theaterId')!, 10);
    movieId: string = this.route.snapshot.paramMap.get('movieId')!;
    schedules?: Schedule[] = [];


    constructor(private scheduleService: ScheduleService, private route: ActivatedRoute) { }

    ngOnInit(): void {
        this.getSchedules();
        this.extractTimes();
    }

    getSchedules(): void {
        this.scheduleService.getSchedule(this.movieId, this.theaterId).subscribe(
            schedules => this.schedules = schedules
        );
    }

    extractTimes(): void {
        if (Array.isArray(this.schedules)) {
            this.schedules.forEach(sch => {
                sch.hour = sch.showingTime.getHours();
                sch.minute = sch.showingTime.getHours();
                console.log(sch.showingTime.getHours());
            });
        }
    }
}
